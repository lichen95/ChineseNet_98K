//定义超时函数显示图一
function chao()
{
    setTimeout(function () {
        //设置图一显示
        document.getElementById("img").style.display = "block";
    },2000);
}
chao();
//定义超时函数显示图二
function shi() {
    setTimeout(function () {
        //显示图二
        document.getElementById("img").src = "/images/" + "06378087189c8b9ff1fa5c8e53e4d92e.jpeg";
    }, 2000);
}
shi();
//定义间隔函数切换图片
function qie()
{
    setInterval(function () {
        //获取图片路径
        var lujing = document.getElementById("img").src;
        //获取相对路径下标
        var xiangdui = lujing.lastIndexOf('/') + 1;
        //截取相对路径
        var m = lujing.substring(xiangdui);
        //图片最终名称
        var img = m == "06378087189c8b9ff1fa5c8e53e4d92e.jpeg" ? "11c88a33eb8443dd4f09189a1c20fa1c.jpeg" : "06378087189c8b9ff1fa5c8e53e4d92e.jpeg";
        //显示图片
        document.getElementById("img").src = "/images/" + img;
    }, 2000);
}
qie();