/*public*/
function getThistime(addh){
	function judge(num){
		num<10? num="0"+num:num=num;
		return num;
	}
	var d=new Date();
	var y=d.getFullYear();
	var m=judge(d.getMonth()+1);
	var day=d.getDate();
	var h=judge(d.getHours());
	if(addh != null && addh!=""){
		var a_h=d.getHours()+addh;
		var th=a_h%24;
		day=Math.floor(a_h/24)+day;
		h=judge(th);//定时发布默认延迟addh小时发布
	}
	var mins=judge(d.getMinutes());
	var s=judge(d.getSeconds());
	day=judge(day);
	var time=y+"-"+m+"-"+day+" "+h+":"+mins+":"+s;
	return time;
}
$(function (){
	/*public*/
	/*模拟下拉框*/
	var selectDom=$(".select_dom");
	if(selectDom.length>0){//存在模拟下拉框
		selectDom.find(".select_nav").click(function (){
			var t=$(this);
			if(t.hasClass("not_select")) return false;
			var o=t.siblings(".option");
			if(o.is(":visible")){
				selectDom.find(".option").hide();
			}
			else{
				selectDom.find(".option").hide();
				o.show();
			}
			return false;
		})
		selectDom.find(".option").delegate("li","click",function (){
			var t=$(this);
			var value=t.text();
			t.parents(".option").hide();
			t.parents(".option").siblings(".select_nav").find(".sel_con").text(value);
			return false;
		});
		$("body").click(function (){
			selectDom.find(".option").hide();
		})
	}
	/*模拟单选框*/
	var radioDom=$(".radio_dom");
	if(radioDom.length>0){
		radioDom.find(".label").click(function (){
			var t=$(this);
			if(t.hasClass("not-allowed")) return false;
			t.addClass("focus").siblings(".label").removeClass("focus");
		});
	}
	/*模拟复选框*/
	var checkboxDom=$(".checkbox");
	if(checkboxDom.length>0){
		checkboxDom.click(function (){
			$(this).hasClass("checked")?$(this).removeClass("checked"):$(this).addClass("checked");
		});
	}
	/*弹窗*/
	var dialogDom=$(".mdialog");
	if(dialogDom.length>0){
		dialogDom.find(".md_close,.md_cancel").click(function (){
			$(this).parents(".mdialog").hide();
		});
	};
});