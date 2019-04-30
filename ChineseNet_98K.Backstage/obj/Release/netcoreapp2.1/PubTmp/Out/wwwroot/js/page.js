var pageIndex = 1;//当前页
var pageCount = 0;//总页数
$(function () {
   
    //全选
    $("#qx").click(function () {
        $("[name=ck]").prop("checked", $(this).prop("checked"));
    })
})
//查询
function search() {
    pageIndex = 1;
    show();
}
//首页
function FirstPage() {
    pageIndex = 1;
    show();
}
//上一页
function PrivePage() {
    if (pageIndex - 1 <= 0) {
        alert("这已经是第一页了");
        return;
    }
    pageIndex -= 1;
    show();
}
//下一页
function NextPage() {
    if (pageIndex + 1 > pageCount) {
        alert("这已经是最后一页了");
        return;
    }
    pageIndex += 1;
    show();
}
//尾页
function LastPage() {
    pageIndex = pageCount;
    show();
}
//批量删除
function ps() {
    var ids = [];
    $("[name=ck]:checked").each(function () {
        ids.push($(this).val());
    })
    console.log(ids);
    if (ids.length == 0) {
        alert("请选择要操作的数据");
        return;
    }
    del(ids);
}
//新增跳转
function add(url) {
    console.log(url);
    //location.href = url;
    //var url = '/Goods/Add?usersId=' + $.cookie('UId');
    window.open(url, "main");
}