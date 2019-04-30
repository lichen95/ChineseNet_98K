document.writeln('<div class="mdialog" id="publicDialog" style="display:none;">');
document.writeln('	<h2><a href="javascript:;" title="关闭" class="pub_ico btn_close md_close fr"></a><span class="md_tit">保存到草稿箱</span></h2>');
/*error tip*/
document.writeln('  <div class="mdchange mdlist">');
document.writeln('  	<div class="md_tips">操作错误提示信息</div>');
document.writeln('      <p align="center"><span class="btn_c_g btn_move btnSure">确定</span></p>');
document.writeln('  </div>')
/*confirm*/
document.writeln('  <div class="mdconfirm mdlist">');
document.writeln('  	<div class="md_tips">您好，您刚刚编辑的章节还没有保存，是否保存到草稿箱？</div>');
document.writeln('      <div class="md_btn"><span class="btn_c_g md_sure btnSure" btntype="save">确定</span><span class="btn_c_g md_cancel btnCancel">取消</span></div>');
document.writeln('  </div>');
/*move*/
document.writeln('  <div class="mdmove mdlist">');
document.writeln(' 	  <div class="volume select_dom">');
document.writeln('     	<p class="select_nav"><em class="cor_gary">分卷</em><em class="voname sel_con"></em></p>');
document.writeln('      <div class="option"></div>');
document.writeln('    </div>');
document.writeln('    <div class="mdchapter clear">');
document.writeln('  	<div class="chaptername select_dom fl">');
document.writeln('        	<em class="cor_gary">章节</em>');
document.writeln('          <p class="select_nav"><em class="sel_con"></em></p>');
document.writeln('          <div class="option"></div>');
document.writeln('      </div>');
document.writeln('      <div class="chapterps select_dom fr">');
document.writeln('         	<em class="cor_gary">位置</em>');
document.writeln('          <p class="select_nav"><em class="sel_con">章节之前</em></p>');
document.writeln('          <ul class="option"><li>章节之前</li><li>卷末</li></ul>');
document.writeln('      </div>');
document.writeln('    </div>');
document.writeln('    <p align="center" class="align"><a href="javascript:;" class="btn_c_g btn_move btnSure">移动</a></p>');
document.writeln('  </div>')
//
document.writeln('</div>');
document.writeln('<div id="publicDialogbg"></div>')

function publicDialog(title,tips,type,fn){
	var dom=$("#publicDialog");
	var dombg=$("#publicDialogbg");
	var domTitle=dom.find(".md_tit");
	var domTip=dom.find(".md_tips");
	var btnClose=dom.find(".md_close");
	var btnSure=dom.find(".btnSure");
	var btnCancel=dom.find(".btnCancel");
	dom.find(".mdlist").eq(type).show().siblings(".mdlist").hide();
	domTitle.html(title);
	domTip.html(tips).show();
	/*计算位置*/
	setDialogps();
	dom.fadeIn();
	dombg.fadeIn();
	btnClose.unbind("click").click(function (){
		closedialog();	
	});
	btnCancel.unbind("click").click(function (){
		closedialog();
	});
	btnSure.unbind("click").click(function (){
		if(fn!=null && typeof(fn)=="function"){
			fn();
		}
		closedialog();
	});
	function closedialog(){
		dom.fadeOut();
		dombg.fadeOut();
		if(type==2){
			var moDom=$("#artList").find(".mod_ps");
			moDom.fadeOut(300).find(".modname").fadeIn();
			setTimeout(function (){
				moDom.removeClass("movethis")
			},301);
		}
	}
	
}
function setDialogps(){
	var dom=$("#publicDialog");
	var dombg=$("#publicDialogbg");
	/*reset value*/
	var body_w=$("body").width();
	var body_h= $("body").height()<$(window).height() ? $(window).height():$("body").height();
	
	var top=Math.floor($(window).height()-dom.height())/2-20;
	var top_2=$(window).scrollTop()+top;
	//btnType=type;
	dom.css("top",top_2);
	dombg.css({"height":body_h});
	var pbh=dom.height();
	var maxh1=pbh-42-76+top-10;
	var maxh2=top+42+20-10;
	dom.find(".volume").find(".option").css("max-height",maxh1);
	dom.find(".chaptername").find(".option").css("max-height",maxh2);
	
}
$(function (){
	$(window).resize(function (){
		setDialogps();
	})
})
