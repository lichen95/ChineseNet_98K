$(function () {
    var clearSentTimer;
    var regTelphone = /^1\d{10}$/;
    var regPassword = /^([A-Za-z0-9]|[~!@#$%^&*()_+`\-={}:";'<>?,.\/]){6,16}$/;
    var regNickname = /^[a-zA-Z0-9_\u4e00-\u9fa5]+$/;
    var phoneCapt = false;//默认没有点击发送短信验证码
    var regCheckbox = $(".reg-check input");
    regCheckbox.change(function () {
        if (!$(this).is(":checked")) {
            $(".next-step").eq(0).addClass("gray");
            return false
        }
        $(".next-step").eq(0).removeClass("gray");
    })

    $(".reg-form").find("input[type='text']").blur(function () {
        var value = $.trim($(this).val());
        if (value == "") return;
        if ($(this).attr("id") == "regphone") {//手机号
            if (!regTelphone.test(value)) {
                $(this).siblings(".placeerror").removeClass("placesucc").html("手机号格式不对，请重新输入").show();
            } else {
                $(this).siblings(".placeerror").addClass("placesucc").html("√ 验证通过").show();
                $(this).parent().next().find("input").removeAttr("readonly");
                isShowCaptkey(value);
            }
        }
        $(".next-step").find(".placeerror").hide();
    }).focus(function () {
        $(this).siblings(".placeerror").hide();
        $(".next-step").find(".placeerror").hide();
    });
    $("#regpassword").blur(function () {
        var value = $(this).val();
        if (value == "") {
            $(this).siblings(".placeerror").removeClass("placesucc").html("密码不能为空").show();
            return;
        }
        if (!regPassword.test(value)) {
            $(this).siblings(".placeerror").removeClass("placesucc").html("密码格式不对，请重新输入").show();
            return;
        } else {
            $(this).siblings(".placeerror").addClass("placesucc").html("√ 验证通过").show();
        }

    }).focus(function () {
        $(this).siblings(".placeerror").hide();
        $(".next-step").find(".placeerror").hide();
    });
    $(".randimg").click(function () {
        var timer = new Date().getTime();
        $(".randimg").attr("src", $(this).attr("data-src") + "&t=" + timer);
    });
    $("#regpassword2").blur(function () {
        var value = $(this).val();
        if (value == "") {
            $(this).siblings(".placeerror").removeClass("placesucc").html("密码不能为空").show();
            return;
        }
        if (value != $("#regpassword").val()) {
            $(this).siblings(".placeerror").removeClass("placesucc").html("两次输入的密码不一致，请重新输入").show();
            return;
        }

        if (!regPassword.test(value)) {
            $(this).siblings(".placeerror").removeClass("placesucc").html("密码格式不对，请重新输入").show();
            return;
        } else {
            $(this).siblings(".placeerror").addClass("placesucc").html("√ 验证通过").show();
        }
    }).focus(function () {
        $(this).siblings(".placeerror").hide();
        $(".next-step").find(".placeerror").hide();
    });
    /*function strlen(str){
        var len = 0;
        for (var i=0; i<str.length; i++) { 
         var c = str.charCodeAt(i); 
        //单字节加1 
         if ((c >= 0x0001 && c <= 0x007e) || (0xff60<=c && c<=0xff9f)) { 
           len++; 
         } 
         else { 
          len+=2; 
         } 
        } 
        return len;
    }*/
    $("#regnickname").blur(function () {
        var value = $.trim($(this).val());
        if (value.length > 12) {
            $(this).siblings(".placeerror").removeClass("placesucc").html("昵称不能超过12个字符").show();
            return;
        }
        if (value.length < 3) {
            $(this).siblings(".placeerror").removeClass("placesucc").html("昵称不能少于3个字符").show();
            return;
        }
        if (!regNickname.test(value)) {
            $(this).siblings(".placeerror").removeClass("placesucc").html("昵称不符合规则").show();
            return;
        } else {
            $(this).siblings(".placeerror").addClass("placesucc").html("√ 验证通过").show();
        }

    }).focus(function () {
        $(this).siblings(".placeerror").hide();
        $(".next-step").find(".placeerror").hide();
    });
    $(".user-btns").find("a").click(function () {
        var telphone = $.trim($("#regphone").val());
        if ($(this).index() == 0) {//去登录
            $.ajax({
                type: "post",
                url: "/dosmsregrecheck.do",
                data: { tk: TK, unam: telphone, checktype: "login", captkey: captKey },
                dataType: "json",
                error: function () {
                    $(".next-step").eq(0).find(".placeerror").html("出错啦，请重试").show();
                }, success: function (data) {
                    if (data.code == 1) {
                        location.href = decodeURIComponent(comeBackUrl);
                    } else if (data.code == 2101 || data.code == 2102) {//过期，需要重新填写
                        emptyStepOne();
                        var errormsg = data.msg || "验证过期，请重新进行验证";
                        $(".next-step").eq(0).find(".placeerror").html(errormsg).show();
                    } else {
                        var errormsg = data.msg || "出错啦，请重试";
                        $(".next-step").eq(0).find(".placeerror").html(errormsg).show();
                        //emptyStepOne();??
                    }
                }
            })

        } else {
            $.ajax({
                type: "post",
                url: "/dosmsregrecheck.do",
                data: { tk: TK, unam: telphone, checktype: "reg", captkey: captKey },
                dataType: "json",
                error: function () {
                    $(".next-step").eq(0).find(".placeerror").html("出错啦，请重试").show();
                }, success: function (data) {
                    if (data.code == 1) {
                        $(".reg-step").eq(1).show().siblings(".reg-step").hide();
                        $(".reg-step-tit").find("li").eq(1).addClass("active").siblings().removeClass("active");
                    } else if (data.code == 2101 || data.code == 2102) {//过期，需要重新填写
                        emptyStepOne();
                        var errormsg = data.msg || "验证过期，请重新进行验证";
                        $(".next-step").eq(0).find(".placeerror").html(errormsg).show();
                    } else if (data.code == 2203) {//手机号注册频繁，需要重新按步骤执行
                        var errormsg = data.msg || "出错啦，请重试";
                        $(".next-step").eq(0).find(".placeerror").show().html(errormsg);
                        phoneCapt = false;
                        //$("#regphone").select();
                        $("#msgyzm,#regyzm").val("");

                    } else {
                        var errormsg = data.msg || "出错啦，请重试";
                        $(".next-step").eq(0).find(".placeerror").html(errormsg).show();
                        //emptyStepOne();??
                    }
                }
            })
        }
        $(".reg-dialog").hide();
    });
    /*清空第一步*/
    function emptyStepOne() {
        $("#regyzm").val("").siblings(".randimg").click();
        clearTimeout(clearSentTimer);
        $("#msgyzm").siblings(".reg-w-btn").html("发送验证码").removeClass("sentend");
    }
    $(".jump-step").children("span").click(function () {
        //$(this).parents(".reg-step").hide().next(".reg-step").show();
        $(".reg-step").eq(2).show().siblings(".reg-step").hide();
        $(".reg-step-tit").hide().find("li").eq(2).addClass("active").siblings().removeClass("active");
    });
    $(".next-step").click(function () {
        var index = $(".reg-step").index($(this).parents(".reg-step"));
        switch (index) {
            case 0:
                userRegister();
                break;
            case 1:
                setUserName();
                break;
            default:
                $(this).parents(".reg-step").hide().next(".reg-step").show();
        }


    });

    /*获取手机验证码*/
    var phoneInterTimer = null;
    var phoneCaptTime = 60;
    var defaultTime = 60;

    function getPhoneYzm(op) {
        //var option = $.extend({tk:TK,captkey:captKey,plat:0},op);
        //var option = $.extend({ tk: TK, captkey: captKey }, op);
        $.ajax({
            type: "post",
            url: "/Users/Send",
            data: op,
            dataType: "json",
            error: function () {
                $("#msgyzm").siblings(".placeerror").show().html("服务器挂啦，请稍后重试!");
                phoneCapt = false;
            },
            success: function (data) {
                if (data.Code == 1) {
                    phoneCapt = true;
                    $("#msgyzm").siblings(".reg-w-btn").html("发送成功(" + phoneCaptTime + ")").addClass("sentend").siblings("input").removeAttr("readonly");
                    //$("#regyzm").siblings(".placeerror").addClass("placesucc").html("√ 验证通过").show();
                    phoneInterTimer = setInterval(function () {
                        phoneCaptTime = phoneCaptTime - 1;
                        $("#msgyzm").siblings(".reg-w-btn").html("发送成功(" + phoneCaptTime + ")");
                        if (phoneCaptTime == 0) {
                            clearInterval(phoneInterTimer);
                            phoneCaptTime = defaultTime;
                            $("#msgyzm").siblings(".reg-w-btn").html("发送验证码").removeClass("sentend");

                        }
                    }, 1000);

                    //captKey = data.data.captkey;
                }
                else if (data.Code == 2302) {
                    var errormsg = data.Msg || "验证码错误";
                    $("#regyzm").siblings(".placeerror").show().html(errormsg).siblings(".randimg").click();
                }
                else {
                    phoneCapt = false;
                    var errormsg = data.Msg || "出错啦，请重试";
                    $("#msgyzm").siblings(".placeerror").show().html(errormsg);
                }
            }
        });
    }
    /*短信注册*/
    function userRegister() {
        if (!regCheckbox.is(":checked")) {
            return false
        }
        if (!phoneCapt) {
            $("#msgyzm").siblings(".placeerror").show().html("请先获取短信验证码");
            return;
        }

        var telphone = $.trim($("#regphone").val());
        var msgyzm = $.trim($("#msgyzm").val());
        var captvalue = $.trim($("#regyzm").val());

        if (telphone == "") {
            $("#regphone").siblings(".placeerror").html("手机号不能为空").show();
            return;
        }
        if (telphone.length != 11 || !regTelphone.test(telphone)) {
            $("#regphone").siblings(".placeerror").html("手机号格式不正确").show()
            return;
        }
        if (msgyzm.length == 0) {
            $("#msgyzm").siblings(".placeerror").html("短信验证码不能为空").show()
            return;
        }
        if ($(".error-more").is(":visible") && captvalue.length != 4) {
            $("#regyzm").siblings(".placeerror").html("验证码格式不正确").show();
            return;
        }
        $(".next-step").eq(0).find(".placeerror").hide();

        $.ajax({
            type: "post",
            url: "/Users/Check",
            data: { unam: telphone, pwd: msgyzm },
            dataType: "json",
            error: function () {
                $(".next-step").eq(0).find(".placeerror").html("服务器挂啦，请稍后重试!").show();
            }, success: function (data) {
                if (data == "" || data == null) return;
                if (data.Code == 1) {
                    $(".reg-step").eq(1).show().siblings(".reg-step").hide();
                    $(".next-step").eq(0).find(".placeerror").hide().html("");
                    $(".reg-step-tit").find("li").eq(1).addClass("active").siblings().removeClass("active");
                    if (data.data && data.data.fillinfo == 1) {
                        $(".jump-step").remove();
                    }
                } else if (data.Code == 2303) {//重新验证
                    var errormsg = data.Msg || "验证码已过期，需要重新进行获取";
                    $("#msgyzm").siblings(".placeerror").show().html(errormsg);
                    $("#regyzm").val("").siblings(".randimg").click();
                    /*$("#msgyzm").val("").siblings(".reg-w-btn").html("发送验证码").removeClass("sendend");
                    $(".next-step").eq(0).find(".placeerror").show().html(errormsg);
                    clearInterval(phoneInterTimer);*/

                } else if (data.Code == 2201) {//短信验证码过期
                    var errormsg = data.Msg || "短信验证码输入错误，请重新输入";
                    $("#msgyzm").siblings(".placeerror").show().html(errormsg);
                    //$("#msgyzm").val("").siblings(".reg-w-btn").html("发送验证码").removeClass("sentend");
                    //$(".next-step").eq(0).find(".placeerror").show().html(errormsg);
                    //clearInterval(phoneInterTimer);
                } else if (data.Code == 2100) {//已注册
                    var user = data.data;
                    var userimg = user.img || "http://static.zongheng.com/userimage/default/image_120_120.gif";
                    $(".reg-dialog").show().find(".user-info").empty().html('<img src="' + userimg + '" class="user-img"><p>' + user.nkm + '</p>');

                } else if (data.Code == 9002) {
                    location.reload();
                } else {
                    var errormsg = data.Msg || "出错啦，请重试";
                    $(".next-step").eq(0).find(".placeerror").show().html(errormsg);
                }
            }
        });
    }
    $("#msgyzm").siblings(".reg-w-btn").click(function () {
        if ($(this).hasClass("sentend")) {
            $(this).siblings(".placeerror").show().html("发送太频繁啦，请您" + phoneCaptTime + "秒后再试");
            return;
        }
        var telphone = $.trim($("#regphone").val());
        if (telphone == "" || !regTelphone.test(telphone)) {
            $("#regphone").siblings(".placeerror").removeClass("placesucc").html("手机号格式不对，请重新输入").show();
            return;
        }

        var picyzm = $.trim($("#regyzm").val());
        if ($(".error-more").is(":visible") && picyzm.length < 4) {
            $("#regyzm").siblings(".placeerror").removeClass("placesucc").html("验证码格式不对，请重新输入").show();
            return;
        }
        $(this).siblings(".placeerror").hide().html("");
        getPhoneYzm({ phone: telphone, capt: picyzm });


        //getPhoneYzm({phone:telphone});
    });
    /*补全用户信息*/
    function setUserName() {
        $("#regpassword").blur();
        $("#regpassword2").blur();
        $("#regnickname").blur();
        var pwd = $("#regpassword").val();
        var repwd = $("#regpassword2").val();
        var nick = $.trim($("#regnickname").val());
        if (pwd == "" || !regPassword.test(pwd) || repwd != pwd) return;
        if (nick == "" || !regNickname.test(nick) || nick.length > 12 || nick.length < 3) return;
        $.ajax({
            type: "post",
            url: "/Users/Register",
            data: { pwd: pwd, nick: nick },
            dataType: "json",
            error: function () {
                $(".next-step").eq(1).find(".placeerror").show().html("服务器挂啦，请稍后重试!");
            }, success: function (data) {
                if (data.Code == 1) {
                    $(".reg-step").eq(2).show().siblings(".reg-step").hide();
                    $(".reg-step-tit").hide();
                } else {
                    var errormsg = data.Msg || "出错啦，请重试";
                    $(".next-step").eq(1).find(".placeerror").show().html(errormsg);
                }
            }
        });
    }
    /*是否显示验证码*/
    function isShowCaptkey(usernum) {
        if (usernum == undefined || usernum == "") return;

        var timer = new Date().getTime();
        $.ajax({
            type: "post",
            url: "/preregcheck.do",
            data: { tk: TK, unam: usernum, t: timer },
            dataType: "json",
            error: function () {

            }, success: function (data) {
                captKey = data.data.captkey || "";
                if (data && data.code == 1) {
                    var src = "https://passport.zongheng.com/passimg?captkey=" + captKey;
                    $(".error-more").show().find(".randimg").attr({ "src": src + "&t=" + Math.random(), "data-src": src });
                    $("#regyzm").focus();
                    //needCapt = true;
                } else {
                    //needCapt = false;
                    $(".error-more").hide();
                }

            }
        });
    }
    isShowCaptkey($("#regphone").val());

});