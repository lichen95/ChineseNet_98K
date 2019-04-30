function appointPage(url, totalPages) {
	var text=document.getElementById("toPage");
	var val=text.value;
	var value=val.replace(/(^\s*)|(\s*$)/g,"");
	var thisValue=$(".pagenumber").find(".now").text();
	if(value=="" || value<1 || isNaN(value) || value>totalPages){
		text.value="";
		return false;
	}
	location.href = url + value;    
}
$(function(){
	var TYPE=$("body").attr("type");
	if(TYPE=="index"){//首页
		var radios=$(".radios");
		var list=$(".booklist");
		var URL=location.href.split("?")[0];
		var index=$("body").attr("serialstatus")=="" ? 0:2-$("body").attr("serialstatus");
		radios.find(".label").eq(index).addClass("focus").siblings().removeClass("focus");
		radios.find(".label").click(function (){
			var t=$(this);
			t.addClass("focus").siblings(".label").removeClass("focus");
			var index=2-t.index();//1:已完结 0:连载中
			location.href=URL+"?serialStatus="+index;
		});
		function delBook(obj,bookId){
			$.ajax({
				"type":"post",
				url:"/book/delete",
				data:{bookId:bookId},
				dataType:"json",
				error: function(e){
					publicDialog("删除作品",e.message,0);
				},
				success:function (data){
					if(data==null || data=="") return false;
					if(data.code==200){
						obj.remove();
						location.reload();
					}
					else{
						publicDialog("删除作品",data.message,0);
					}
				}
			});
		}
		list.find(".delbook").click(function (){
			var t=$(this);
			var oLi=t.parents("li");
			var bookid=$.trim(oLi.find(".number").text());
			publicDialog("删除作品","作品删除后将无法恢复，确定删除？",1,function (){
				delBook(oLi,bookid);
			});
		});
		list.find(".color_link").find(".cor_a").click(function (){
			var t=$(this);
			var oLi=t.parents("li");
			var str=t.text();
			var btnstr="提交审核";
			var bookid=$.trim(oLi.find(".number").text());
			var parent=t.parent(".color_link");
			if(str.indexOf(btnstr)==-1) return false;
			$.ajax({
				"type":"post",
				url:"/book/authorize",
				data:{bookId:bookid},
				dataType:"json",
				error: function(e){
					publicDialog("提交审核",e.message,0);
				},
				success:function (data){
					if(data==null || data=="") return false;
					if(data.code==200){
						oLi.addClass("unuse").append('<div class="notlink"></div>').find(".delbook").remove();
						parent.hide().siblings(".bookstate").text("待审核");
					}
					else{
						publicDialog("提交审核",data.message,0);
					}
				}
			});
		});
		/*引导cookie*/
		function setCookie(name,value){
			var Days = 365;
			var exp = new Date();
			exp.setTime(exp.getTime() + Days*24*60*60*1000);
			document.cookie = name + "="+ escape (value) + ";expires=" + exp.toGMTString();
		}
		function getCookie(name){
			var arr,reg=new RegExp("(^| )"+name+"=([^;]*)(;|$)");
			if(arr=document.cookie.match(reg))
			return unescape(arr[2]);
			else
			return null;
		}
		if(getCookie("setringRead") != "read"){
			if($(".booklist").find(".btn_manage").length==0) return false;
			var larH=$("body").height()>$(window).height()?$("body").height():$(window).height();
			var html='<div class="fixring" style="background-color:rgba(0,0,0,0.6);position:absolute;left:0;top:0;width:100%;height:'+larH+'px;z-index:999;"><div class="ringtip" style="width:305px;height:246px;background-image:url(http://static.zongheng.com/author/v2015/images/ring.png);position:absolute;left:50%;top:412px;margin-left:90px;overflow:hidden;"><div class="closering" style="cursor:pointer;width:72px;height:38px;margin:192px 0 0 233px;" title="已知晓"></div></div></div>';
			$("body").append(html);
			$(".fixring").find(".closering").click(function (){
				setCookie("setringRead","read");
				$(this).parents(".fixring").remove();
			});
		}
	}
});