$(function (){
	var draftBox=$(".au_draft");
	var mailBox=$(".au_mail");
	/*增加返回按钮*/
	function addBackPrePage(dom){
		var URL=document.referrer||"http://"+location.host;
		
		var addhtml='<a href="'+URL+'" style="float:right; font-size:14px; color:#1abc9c; letter-spacing:1px;font-family:\'Microsoft YaHei\';line-height:40px;">返回<em style="letter-spacing:-2px; padding-left:2px;">&gt;&gt;</em></a>';
		dom.append(addhtml);
	}
	addBackPrePage(mailBox.find(".mail_nav").eq(0));
	/*增加返回按钮结束*/
	function resetDraftbox(){
		var h=$(window).height();
		var mh=h-170-120;
		if(draftBox.size()>0){
			var nh=mh-88;
			if(draftBox.find(".nothing").size()>0){
				
				draftBox.find(".nothing").css({"height":nh,"line-height":nh+"px"});
			}
			/*draftBox.css("min-height",mh).find(".table").css("min-height",nh-93);*/
		}
		if(mailBox.size()>0){
			if(mailBox.find(".nothing").size()>0){
				var nh=mh-39-44-20;
				mailBox.find(".nothing").css({"height":nh,"line-height":nh+"px"});
			}
			mailBox.css("min-height",mh);
		}
		
	}
	$(window).resize(function (){
		resetDraftbox();
	});
	if(mailBox.size()>0){
		resetDraftbox();
		var listtr=$(".tr");
		listtr.find(".allmsg").click(function (){
			var parent=$(this).parents(".msg_side");
			parent.hide().siblings(".msg_wide").show();
			if(parent.parents(".tr").hasClass("newmsg")){
				parent.parents(".tr").removeClass("newmsg");
			}
			var messageId=parent.parents(".tr").attr("messageId");
			$.ajax({
				"type":"post",
				url:"/author/messageupdate",
				data:{messageId:messageId},
				dataType:"json",
				error: function(e){},
				success:function (d){
					if(d==null || d=="") return false;
					if(d.code==200){
						
					}	
				}
			})
		});
		listtr.find(".onemsg").click(function (){
			var parent=$(this).parents(".msg_wide");
			parent.hide().siblings(".msg_side").show();
		});
	}
	if(draftBox.size()>0){//存稿箱
		var backUrl=document.referrer || "http://"+location.host;
		draftBox.find(".backup").attr("href",backUrl);
		var bookId=$("body").attr("bookid");
		var bookEnd=$("body").attr("serialstatus")==1;
		function loadPage(mode,num){
			var timmer=new Date().getTime();
			$(window).scrollTop(100);
			num=parseInt(num);
			//1：草稿    2：定时发布
			$.ajax({
				"type":"post",
				url:"/book/draft/list",
				data:{bookId:bookId,mode:mode,pageNo:num,t:timmer},
				dataType:"json",
				error: function(e){},
				success:function (d){
					if(d==null || d=="") return false;
					var draft=d.result;
					var list=draft.draftList;
					var index=mode-1;
					if(list!=null&& list!=""){
						var total=draft.totalCount;
						var totalPage=Math.ceil(total/draft.pageSize);
						var html='';
						if(mode==1){//存稿
							for(var i=0,len=list.length;i<len;i++){
								
								html+='<li class="clear tr" draftid="'+list[i].draftId+'"><div class="td art_name"><div class="artname">'+list[i].tomeName+'<p>'+list[i].chapterName+'</p></div></div><div class="td art_num">'+list[i].wordNum+'</div><div class="td art_levl">';
								if(list[i].level==1){
									html+='<em class="vip">VIP</em>';
								}
								else{
									html+='免费';
								}
								html+='</div><div class="td art_time">';
								if(list[i].isSave==0){
									html+="临时保存";
								}
								else{
									html+='手动保存';
								}
								html+='</div><div class="td art_submit">'+list[i].createTime+'</div>';
								if(bookEnd){
									html+='<a href="javascript:;" class="exchange nota">查看</a>';
								}
								else{
									html+='<a href="javascript:;" class="exchange">修改</a>';
								}
								html+='<a href="javascript:;" class="delart">删除</a></div></li>';
							}
							
						}
						else{
							for(var i=0,len=list.length;i<len;i++){
								if(list[i].isPubFail&&list[i].isPubFail==1){
									html+='<li class="clear tr not" draftid="'+list[i].draftId+'"><div class="td art_name"><div class="artname">'+list[i].tomeName+'<p>'+list[i].chapterName+'</p></div></div><div class="td art_num">'+list[i].wordNum+'</div><div class="td art_levl">';
								}else{
									html+='<li class="clear tr" draftid="'+list[i].draftId+'"><div class="td art_name"><div class="artname">'+list[i].tomeName+'<p>'+list[i].chapterName+'</p></div></div><div class="td art_num">'+list[i].wordNum+'</div><div class="td art_levl">';
								}
								
								if(list[i].level==1){
									html+='<em class="vip">VIP</em>';
								}
								else{
									html+='免费';
								}
								if(list[i].isPubFail&&list[i].isPubFail==1){
									html+='</div><div class="td art_time">'+list[i].createTime+'</div><div class="td art_submit"><em class="error">'+list[i].releaseTime+'发布失败</em></div>';
								}else{
									html+='</div><div class="td art_time">'+list[i].createTime+'</div><div class="td art_submit">'+list[i].releaseTime+'</div>';
								}
								html+='<div class="td art_manage">';
								if(bookEnd){
									html+='<a href="javascript:;" class="exchange nota">查看</a>';
								}
								else{
									html+='<a href="javascript:;" class="exchange">修改</a>';
								}
								html+='<a href="javascript:;" class="delart">删除</a></div></li>';
							}
						}
						draftBox.find(".draftbox").eq(index).find(".table").html(html);
						draftBox.find(".draftbox").find(".delart").unbind("click").click(function (){
							var draftid=$(this).parents(".tr").attr("draftid");
							if(index==0){
								publicDialog("删除草稿","草稿删除后将无法恢复，确定删除？",1,function (){
									delDraft(draftid,mode,num);
								})
							}
							else{
								publicDialog("删除定时发布章节","删除定时发布章节后将无法恢复，确定删除？",1,function (){
									delDraft(draftid,mode,num);
								})
							}
							
						});
						draftBox.find(".exchange").click(function (){
							var t=$(this);
							var draftid=t.parents(".tr").attr("draftid");
							if(t.hasClass("nota")){
								location.href="/book/chapter/show?bookId="+bookId+"&draftId="+draftid;
								return false;
							}
							var i=t.parents(".draftbox").index();
							if(i==1){
								publicDialog("编辑定时发布章节","编辑过程中之前设置的定时发布时间会自动失效，<br>需重新设置，继续编辑？",1,function (){
									exChange(draftid);
								})
							}
							else{
								publicDialog("编辑草稿","确定要编辑当前草稿吗？",1,function (){
									exChange(draftid);
								});
							}
						})
						//显示页码
						var isFirstpage= num==1;
						var isLastpage= num==totalPage;
						var prevnum=parseInt(num)-1;
						var nextnum=parseInt(num)+1;
						var pagehtml="";
						isFirstpage ? pagehtml+='<a href="javascript:;" class="page_prev last">上一页</a>':pagehtml+='<a href="javascript:;" title="上一页" class="page_prev" page="'+prevnum+'">上一页</a>';
						var larPage=7;//最多显示的页码数
						if(totalPage <= larPage){
							for(var i=0;i<totalPage;i++){
								var n=i+1;
								n==num ? pagehtml+='<a href="javascript:;" class="now">'+n+'</a>':pagehtml+='<a href="javascript:;" page="'+n+'">'+n+'</a>';
							}
						}
						else{
							var beforenum=num-3;
							var afternum=num+3;
							if(beforenum<0){
								afternum=afternum+Math.abs(beforenum);
								beforenum=1;
							}
							else if(afternum>totalPage){
								beforenum=beforenum-Math.abs(afternum-totalPage);
								afternum=totalPage;
							}
							for(var i=0;i<totalPage;i++){
								var n=i+1;
								if(n>=beforenum&&n<=afternum){
									if(num-3>0){
										if(n==num) {pagehtml+='<a href="javascript:;" class="now">'+n+'</a>'}
										else if(n==beforenum){pagehtml+='<a href="javascript:;" page="1">1</a> ··· ';}
										else{
											if(afternum<totalPage){
												if(n!=afternum){
													pagehtml+='<a href="javascript:;" page="'+n+'">'+n+'</a>';
												}
											}
											else{
												pagehtml+='<a href="javascript:;" page="'+n+'">'+n+'</a>';
											}
										}
									}
									else{
										if(n==num) {pagehtml+='<a href="javascript:;" class="now">'+n+'</a>'}
										else{
											pagehtml+='<a href="javascript:;" page="'+n+'">'+n+'</a>';
										}
									}
								}
							}
							if(num+3<totalPage){
								pagehtml+=' ··· <a href="javascript:;" page="'+totalPage+'">'+totalPage+'</a>';
							}
						}
						isLastpage ? pagehtml+='<a href="javascript:;" class="page_next last">下一页</a>':pagehtml+='<a href="javascript:;" title="下一页" class="page_next" page="'+nextnum+'">下一页</a>';
						var jumpNum=num<=totalPage?num:totalPage;
						var phtml='总计'+draft.totalCount+'记录'+pagehtml+'至第<input class="jumpvalue" maxlength="3" value="'+jumpNum+'" type="text">页 <input class="submit" value="跳转" type="button">';
						draftBox.find(".draftbox").eq(index).find(".pagenumber").html(phtml);
						draftBox.find(".pagenumber").children("a").unbind("click").bind("click",function (){
							var t=$(this);
							if(t.hasClass("last")||t.hasClass("now")) return false;
							var pagenum=t.attr("page");
							var jumpmode=t.parents(".draftbox").index()+1;
							loadPage(jumpmode,pagenum);
						}).siblings(".submit").unbind("click").click(function (){
							var t=$(this);
							var value=$.trim(t.siblings(".jumpvalue").val());
							if(value=="" || value<1 || isNaN(value) || value>totalPage){
								t.siblings(".jumpvalue").val("");
								return false;
							}
							var jumpmode=t.parents(".draftbox").index()+1;
							loadPage(jumpmode,value);
							
						});
					
					}
					else{//没有
						var nohtml="";
						if(mode==1){
							nohtml+='<div class="nothing">您当前暂无草稿 ( ´◔ ‸◔` ) </div>';
						}
						else{
							nohtml+='<div class="nothing">您当前暂无定时发布章节 ( ´◔ ‸◔` ) </div>'
						}
						draftBox.find(".draftbox").eq(index).empty().html(nohtml);
					}
					resetDraftbox();
				}
			})
		}
		function delDraft(draftid,mode,num){
			$.ajax({
				"type":"post",
				url:"/book/draft/delete",
				data:{bookId:bookId,draftId:draftid},
				dataType:"json",
				error: function(e){
					publicDialog("删除",e.message,0);
				},
				success:function (d){
					if(d==null || d=="") return false;
					if(d.code==200){
						draftBox.find("li[draftid="+draftid+"]").remove();
						loadPage(mode,num);
					}
					else{
						publicDialog("删除",d.message,0);
					}
				}
			})
		}
		function exChange(draftid){
			$.ajax({
				"type":"post",
				url:"/book/draft/update",
				data:{bookId:bookId,draftId:draftid},
				dataType:"json",
				error: function(e){
					publicDialog("修改",e.message,0);
				},
				success:function (d){
					if(d==null || d=="") return false;
					if(d.code==200){
						location.href="/book/chapter/show?bookId="+bookId+"&draftId="+draftid;
					}
					else{
						publicDialog("修改",d.message,0);
					}
				}
			})
		}
		loadPage(1,1);
		setTimeout(loadPage(2,1),500);
		$(".draft_nav").find("span").click(function(){
			var t=$(this);
			var i=t.index();
			t.addClass("focus").siblings().removeClass("focus");
			var moveWidth=$(".draftbox").eq(i).width();
			$(".draft_boxs").stop().animate({marginLeft:-i*moveWidth},1000);
		})
	}
	
})