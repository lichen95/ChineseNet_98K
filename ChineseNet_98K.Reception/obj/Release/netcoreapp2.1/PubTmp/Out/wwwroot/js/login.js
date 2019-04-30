//update 2018-10-10
function HelloShit(e, t, i, a) {
    this.e = biFromHex(e), this.d = biFromHex(t), this.m = biFromHex(i), this.chunkSize = "number" != typeof a ? 2 * biHighIndex(this.m) : a / 8, this.radix = 16, this.barrett = new BarrettMu(this.m)
}
function hzasieckses(e, t, i, a) {
    var r, n, s, o, c, d, l, g, m, u = new Array, h = t.length, b = "";
    for (o = "string" == typeof i ? i == RSAAPP.NoPadding ? 1 : i == RSAAPP.PKCS1Padding ? 2 : 0 : 0, c = "string" == typeof a && a == RSAAPP.RawEncoding ? 1 : 0, 1 == o ? h > e.chunkSize && (h = e.chunkSize) : 2 == o && h > e.chunkSize - 11 && (h = e.chunkSize - 11), r = 0, n = 2 == o ? h - 1 : e.chunkSize - 1; r < h;)o ? u[n] = t.charCodeAt(r) : u[r] = t.charCodeAt(r), r++ , n--; for (1 == o && (r = 0), n = e.chunkSize - h % e.chunkSize; n > 0;) {
        if (2 == o) { for (d = Math.floor(256 * Math.random()); !d;)d = Math.floor(256 * Math.random()); u[r] = d }
        else u[r] = 0; r++ , n--
    }
    for (2 == o && (u[h] = 0, u[e.chunkSize - 2] = 2, u[e.chunkSize - 1] = 0), l = u.length, r = 0; r < l; r += e.chunkSize) {
        for (g = new BigInt, n = 0, s = r; s < r + e.chunkSize; ++n)g.digits[n] = u[s++], g.digits[n] += u[s++] << 8; m = e.barrett.powMod(g, e.e), b += 1 == c ? biToBytes(m) : 16 == e.radix ? biToHex(m) : biToString(m, e.radix)
    } return b
}
function decryptedString(e, t) {
    var i, a, r, n, s = t.split(" "), o = ""; for (a = 0; a < s.length; ++a)for (n = 16 == e.radix ? biFromHex(s[a]) : biFromString(s[a], e.radix), i = e.barrett.powMod(n, e.d), r = 0; r <= biHighIndex(i); ++r)o += String.fromCharCode(255 & i.digits[r], i.digits[r] >> 8); return 0 == o.charCodeAt(o.length - 1) && (o = o.substring(0, o.length - 1)), o
}
function BarrettMu(e) {
    this.modulus = biCopy(e), this.k = biHighIndex(this.modulus) + 1; var t = new BigInt; t.digits[2 * this.k] = 1, this.mu = biDivide(t, this.modulus), this.bkplus1 = new BigInt, this.bkplus1.digits[this.k + 1] = 1, this.modulo = BarrettMu_modulo, this.multiplyMod = BarrettMu_multiplyMod, this.powMod = BarrettMu_powMod
}
function BarrettMu_modulo(e) {
    var t = biDivideByRadixPower(biMultiply(biDivideByRadixPower(e, this.k - 1), this.mu), this.k + 1), i = biSubtract(biModuloByRadixPower(e, this.k + 1), biModuloByRadixPower(biMultiply(t, this.modulus), this.k + 1)); i.isNeg && (i = biAdd(i, this.bkplus1)); for (var a = biCompare(i, this.modulus) >= 0; a;)i = biSubtract(i, this.modulus), a = biCompare(i, this.modulus) >= 0; return i
}
function BarrettMu_multiplyMod(e, t) {
    var i = biMultiply(e, t); return this.modulo(i)
}
function BarrettMu_powMod(e, t) {
    var i = new BigInt; i.digits[0] = 1; for (var a = e, r = t; 0 != (1 & r.digits[0]) && (i = this.multiplyMod(i, a)), 0 != (r = biShiftRight(r, 1)).digits[0] || 0 != biHighIndex(r);)a = this.multiplyMod(a, a); return i
}
function setMaxDigits(e) {
    maxDigits = e, ZERO_ARRAY = new Array(maxDigits); for (var t = 0; t < ZERO_ARRAY.length; t++)ZERO_ARRAY[t] = 0; bigZero = new BigInt, (bigOne = new BigInt).digits[0] = 1
}
function BigInt(e) {
    this.digits = "boolean" == typeof e && 1 == e ? null : ZERO_ARRAY.slice(0), this.isNeg = !1
}
function biFromDecimal(e) {
    for (var t, i = "-" == e.charAt(0), a = i ? 1 : 0; a < e.length && "0" == e.charAt(a);)++a; if (a == e.length) t = new BigInt; else { var r = (e.length - a) % dpl10; for (0 == r && (r = dpl10), t = biFromNumber(Number(e.substr(a, r))), a += r; a < e.length;)t = biAdd(biMultiply(t, lr10), biFromNumber(Number(e.substr(a, dpl10)))), a += dpl10; t.isNeg = i } return t
}
function biCopy(e) {
    var t = new BigInt(!0); return t.digits = e.digits.slice(0), t.isNeg = e.isNeg, t
}
function biFromNumber(e) {
    var t = new BigInt; t.isNeg = e < 0, e = Math.abs(e); for (var i = 0; e > 0;)t.digits[i++] = e & maxDigitVal, e >>= biRadixBits; return t
}
function reverseStr(e) {
    for (var t = "", i = e.length - 1; i > -1; --i)t += e.charAt(i); return t
}
function biToString(e, t) {
    var i = new BigInt; i.digits[0] = t; for (var a = biDivideModulo(e, i), r = hexatrigesimalToChar[a[1].digits[0]]; 1 == biCompare(a[0], bigZero);)a = biDivideModulo(a[0], i), digit = a[1].digits[0], r += hexatrigesimalToChar[a[1].digits[0]]; return (e.isNeg ? "-" : "") + reverseStr(r)
}
function biToDecimal(e) {
    var t = new BigInt; t.digits[0] = 10; for (var i = biDivideModulo(e, t), a = String(i[1].digits[0]); 1 == biCompare(i[0], bigZero);)i = biDivideModulo(i[0], t), a += String(i[1].digits[0]); return (e.isNeg ? "-" : "") + reverseStr(a)
}
function digitToHex(e) {
    var t = ""; for (i = 0; i < 4; ++i)t += hexToChar[15 & e], e >>>= 4; return reverseStr(t)
}
function biToHex(e) {
    for (var t = "", i = (biHighIndex(e), biHighIndex(e)); i > -1; --i)t += digitToHex(e.digits[i]); return t
}
function charToHex(e) {
    return e >= 48 && e <= 57 ? e - 48 : e >= 65 && e <= 90 ? 10 + e - 65 : e >= 97 && e <= 122 ? 10 + e - 97 : 0
}
function hexToDigit(e) {
    for (var t = 0, i = Math.min(e.length, 4), a = 0; a < i; ++a)t <<= 4, t |= charToHex(e.charCodeAt(a)); return t
}
function biFromHex(e) {
    for (var t = new BigInt, i = e.length, a = 0; i > 0; i -= 4, ++a)t.digits[a] = hexToDigit(e.substr(Math.max(i - 4, 0), Math.min(i, 4))); return t
}
function biFromString(e, t) {
    var i = "-" == e.charAt(0), a = i ? 1 : 0, r = new BigInt, n = new BigInt; n.digits[0] = 1; for (var s = e.length - 1; s >= a; s--) { r = biAdd(r, biMultiplyDigit(n, charToHex(e.charCodeAt(s)))), n = biMultiplyDigit(n, t) } return r.isNeg = i, r
}
function biToBytes(e) {
    for (var t = "", i = biHighIndex(e); i > -1; --i)t += digitToBytes(e.digits[i]); return t
}
function digitToBytes(e) {
    var t = String.fromCharCode(255 & e); e >>>= 8; return String.fromCharCode(255 & e) + t
}
function biDump(e) {
    return (e.isNeg ? "-" : "") + e.digits.join(" ")
}
function biAdd(e, t) {
    var i; if (e.isNeg != t.isNeg) t.isNeg = !t.isNeg, i = biSubtract(e, t), t.isNeg = !t.isNeg; else { i = new BigInt; for (var a, r = 0, n = 0; n < e.digits.length; ++n)a = e.digits[n] + t.digits[n] + r, i.digits[n] = 65535 & a, r = Number(a >= biRadix); i.isNeg = e.isNeg } return i
}
function biSubtract(e, t) {
    var i; if (e.isNeg != t.isNeg) t.isNeg = !t.isNeg, i = biAdd(e, t), t.isNeg = !t.isNeg; else { i = new BigInt; var a, r; r = 0; for (n = 0; n < e.digits.length; ++n)a = e.digits[n] - t.digits[n] + r, i.digits[n] = 65535 & a, i.digits[n] < 0 && (i.digits[n] += biRadix), r = 0 - Number(a < 0); if (-1 == r) { r = 0; for (var n = 0; n < e.digits.length; ++n)a = 0 - i.digits[n] + r, i.digits[n] = 65535 & a, i.digits[n] < 0 && (i.digits[n] += biRadix), r = 0 - Number(a < 0); i.isNeg = !e.isNeg } else i.isNeg = e.isNeg } return i
}
function biHighIndex(e) {
    for (var t = e.digits.length - 1; t > 0 && 0 == e.digits[t];)--t; return t
}
function biNumBits(e) {
    var t, i = biHighIndex(e), a = e.digits[i], r = (i + 1) * bitsPerDigit; for (t = r; t > r - bitsPerDigit && 0 == (32768 & a); --t)a <<= 1; return t
}
function biMultiply(e, t) {
    for (var i, a, r, n = new BigInt, s = biHighIndex(e), o = biHighIndex(t), c = 0; c <= o; ++c) { for (i = 0, r = c, j = 0; j <= s; ++j, ++r)a = n.digits[r] + e.digits[j] * t.digits[c] + i, n.digits[r] = a & maxDigitVal, i = a >>> biRadixBits; n.digits[c + s + 1] = i } return n.isNeg = e.isNeg != t.isNeg, n
}
function biMultiplyDigit(e, t) {
    var i, a, r; result = new BigInt, i = biHighIndex(e), a = 0; for (var n = 0; n <= i; ++n)r = result.digits[n] + e.digits[n] * t + a, result.digits[n] = r & maxDigitVal, a = r >>> biRadixBits; return result.digits[1 + i] = a, result
}
function arrayCopy(e, t, i, a, r) {
    for (var n = Math.min(t + r, e.length), s = t, o = a; s < n; ++s, ++o)i[o] = e[s]
}
function biShiftLeft(e, t) {
    var i = Math.floor(t / bitsPerDigit), a = new BigInt; arrayCopy(e.digits, 0, a.digits, i, a.digits.length - i); for (var r = t % bitsPerDigit, n = bitsPerDigit - r, s = a.digits.length - 1, o = s - 1; s > 0; --s, --o)a.digits[s] = a.digits[s] << r & maxDigitVal | (a.digits[o] & highBitMasks[r]) >>> n; return a.digits[0] = a.digits[s] << r & maxDigitVal, a.isNeg = e.isNeg, a
}
function biShiftRight(e, t) {
    var i = Math.floor(t / bitsPerDigit), a = new BigInt; arrayCopy(e.digits, i, a.digits, 0, e.digits.length - i); for (var r = t % bitsPerDigit, n = bitsPerDigit - r, s = 0, o = s + 1; s < a.digits.length - 1; ++s, ++o)a.digits[s] = a.digits[s] >>> r | (a.digits[o] & lowBitMasks[r]) << n; return a.digits[a.digits.length - 1] >>>= r, a.isNeg = e.isNeg, a
}
function biMultiplyByRadixPower(e, t) {
    var i = new BigInt; return arrayCopy(e.digits, 0, i.digits, t, i.digits.length - t), i
}
function biDivideByRadixPower(e, t) {
    var i = new BigInt; return arrayCopy(e.digits, t, i.digits, 0, i.digits.length - t), i
}
function biModuloByRadixPower(e, t) {
    var i = new BigInt; return arrayCopy(e.digits, 0, i.digits, 0, t), i
}
function biCompare(e, t) {
    if (e.isNeg != t.isNeg) return 1 - 2 * Number(e.isNeg); for (var i = e.digits.length - 1; i >= 0; --i)if (e.digits[i] != t.digits[i]) return e.isNeg ? 1 - 2 * Number(e.digits[i] > t.digits[i]) : 1 - 2 * Number(e.digits[i] < t.digits[i]); return 0
}
function biDivideModulo(e, t) {
    var i, a, r = biNumBits(e), n = biNumBits(t), s = t.isNeg; if (r < n) return e.isNeg ? (i = biCopy(bigOne), i.isNeg = !t.isNeg, e.isNeg = !1, t.isNeg = !1, a = biSubtract(t, e), e.isNeg = !0, t.isNeg = s) : (i = new BigInt, a = biCopy(e)), new Array(i, a); i = new BigInt, a = e; for (var o = Math.ceil(n / bitsPerDigit) - 1, c = 0; t.digits[o] < biHalfRadix;)t = biShiftLeft(t, 1), ++c, ++n, o = Math.ceil(n / bitsPerDigit) - 1; a = biShiftLeft(a, c), r += c; for (var d = Math.ceil(r / bitsPerDigit) - 1, l = biMultiplyByRadixPower(t, d - o); -1 != biCompare(a, l);)++i.digits[d - o], a = biSubtract(a, l); for (var g = d; g > o; --g) { var m = g >= a.digits.length ? 0 : a.digits[g], u = g - 1 >= a.digits.length ? 0 : a.digits[g - 1], h = g - 2 >= a.digits.length ? 0 : a.digits[g - 2], b = o >= t.digits.length ? 0 : t.digits[o], f = o - 1 >= t.digits.length ? 0 : t.digits[o - 1]; i.digits[g - o - 1] = m == b ? maxDigitVal : Math.floor((m * biRadix + u) / b); for (var p = i.digits[g - o - 1] * (b * biRadix + f), v = m * biRadixSquared + (u * biRadix + h); p > v;)--i.digits[g - o - 1], p = i.digits[g - o - 1] * (b * biRadix | f), v = m * biRadix * biRadix + (u * biRadix + h); (a = biSubtract(a, biMultiplyDigit(l = biMultiplyByRadixPower(t, g - o - 1), i.digits[g - o - 1]))).isNeg && (a = biAdd(a, l), --i.digits[g - o - 1]) } return a = biShiftRight(a, c), i.isNeg = e.isNeg != s, e.isNeg && (i = s ? biAdd(i, bigOne) : biSubtract(i, bigOne), t = biShiftRight(t, c), a = biSubtract(t, a)), 0 == a.digits[0] && 0 == biHighIndex(a) && (a.isNeg = !1), new Array(i, a)
}
function biDivide(e, t) {
    return biDivideModulo(e, t)[0]
}
function biModulo(e, t) {
    return biDivideModulo(e, t)[1]
}
function biMultiplyMod(e, t, i) {
    return biModulo(biMultiply(e, t), i)
}
function biPow(e, t) {
    for (var i = bigOne, a = e; 0 != (1 & t) && (i = biMultiply(i, a)), 0 != (t >>= 1);)a = biMultiply(a, a); return i
}
function biPowMod(e, t, i) {
    for (var a = bigOne, r = e, n = t; 0 != (1 & n.digits[0]) && (a = biMultiplyMod(a, r, i)), 0 != (n = biShiftRight(n, 1)).digits[0] || 0 != biHighIndex(n);)r = biMultiplyMod(r, r, i); return a
}
var RSAAPP = {};
RSAAPP.NoPadding = "NoPadding", RSAAPP.PKCS1Padding = "PKCS1Padding", RSAAPP.RawEncoding = "RawEncoding", RSAAPP.NumericEncoding = "NumericEncoding";
var maxDigits, ZERO_ARRAY, bigZero, bigOne, biRadixBase = 2, biRadixBits = 16, bitsPerDigit = biRadixBits, biRadix = 65536, biHalfRadix = biRadix >>> 1, biRadixSquared = biRadix * biRadix, maxDigitVal = biRadix - 1, maxInteger = 9999999999999998; setMaxDigits(20);
var dpl10 = 15, lr10 = biFromNumber(1e15), hexatrigesimalToChar = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"), hexToChar = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f"), highBitMasks = new Array(0, 32768, 49152, 57344, 61440, 63488, 64512, 65024, 65280, 65408, 65472, 65504, 65520, 65528, 65532, 65534, 65535), lowBitMasks = new Array(0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535);
$(document).ready(function (e) {
    var t = t || {};
    t.logout = function () {
        location.href = "http://passport.zongheng.com/logout.do?callback=" + encodeURIComponent(location.host) + "&rnd=" + (new Date).getTime()
    }, t.login = function () {
        location.href = Domain.passportHostName + "/?location=" + encodeURIComponent(window.location.href)
    };
    var i = i || {
        login: function () {
            if (String.prototype.trim = function () { return this.replace(/(^\s*)|(\s*$)/g, "") }, "" == e("#authorPwd").val().trim()) return e("div[data-errcode=100]").html("密码不能为空").show(), !1; setMaxDigits(130); var t = new HelloShit(e("body").attr("e"), "", e("body").attr("m")); e("#authorPwd").val(hzasieckses(t, encodeURIComponent(e("#authorPwd").val()))), e("[data-hook=subbtn]").val("登录中...")
        }, smslogin: function () { return e("#cellnumber").val() ? e("#smscode").val() ? void 0 : (e("[data-hook=sendcodeerr]").html("请填写动态密码").show(), e("#smscode").focus(), !1) : (e("[data-errcode=106]").html("请填写手机号").show(), e("#cellnumber").focus(), !1) }
    },
        a = (React.createClass({
            displayName: "DomInit",
            getInitialState: function () {
                return { login: window.user }
            },
            render: function () { }
        }),
            React.createClass({
                displayName: "UserAlert",
                render: function () {
                    return "true" != this.props.isAuthor ? React.createElement("react", null, this.props.name ? React.createElement("span", null, "HI，", this.props.name, "，您已登录纵横，成为作者只差一步！") : React.createElement("span", { onClick: t.login, style: { cursor: "pointer" } }, "亲爱的用户，请先登录纵横中文网，才能创作！")) : React.createElement("react", null, this.props.name ? React.createElement("span", null, "HI，", this.props.name, "，您已登录纵横，快去写作吧！") : React.createElement("span", { onClick: t.login, style: { cursor: "pointer" } }, "亲爱的用户，请先登录纵横中文网，才能创作！"))
                }
            })),
        r = React.createClass({
            displayName: "LoginBox", getInitialState: function () {
                return "true" == this.props.issms ? { logintype: "sms", smsdis: "block", comdis: "none", errorcode: e("body").attr("rescode"), errmsg: e("body").attr("resmsg"), imgcode: e("body").attr("imgcode") } : { logintype: "common", smsdis: "none", comdis: "block", errorcode: e("body").attr("rescode"), errmsg: e("body").attr("resmsg"), imgcode: e("body").attr("imgcode") }
            }, changelogintype: function () {
                "common" == this.state.logintype ? this.setState({ logintype: "sms", smsdis: "block", comdis: "none" }) : this.setState({ logintype: "common", smsdis: "none", comdis: "block" })
            }, forgetPass: function () {
                location.href = "/nau/find"
            }, regAuthor: function () {
                location.href = "/nau/register"
            }, componentDidMount: function () {
                var t = this.props; e("[data-hook=input]").focus(function () { e(this).closest(".ipt_box").addClass("current") }).blur(function () { e(this).closest(".ipt_box").removeClass("current") }), e(".regAuthor").click(function () { "true" == t.isAuthor ? e(this).closest("form").find(".formtit").html("您已是作者，请直接登录") : location.href = "/nau/register" }), "true" == this.state.imgcode && e("[data-hook=dycode]").show(), "" != this.state.errorcode && ("|114|50".indexOf(this.state.errorcode) > 0 ? e("[data-errcode=100]").html(this.state.errmsg).show() : "|102|107|51".indexOf(this.state.errorcode) > 0 ? e("[data-errcode=106]").html(this.state.errmsg).show() : e("[data-errcode=" + this.state.errorcode + "]").html(this.state.errmsg).show())
            }, getsmsCode: function () {
                if (!/^1[0-9][0-9]\d{4,8}$/.test(e("#cellnumber").val())) return e("[data-errcode=106]").html("手机号格式不正确").show(), e("#cellnumber").focus(), !1; e("[data-errcode=106]").hide(), e.ajax({ type: "post", url: "/nau/dycode/mobile", data: { mobile: e("#cellnumber").val(), busType: "lm" }, dataType: "json", async: !0, error: function () { }, success: function (t) { if (console.log(t), 500 == t.code) return e("[data-hook=sendcodeerr]").html(t.message).show(), !1; e("#timerbtn,[data-hook=sendcodeerr]").hide(), e("#timerbox").show(), React.render(React.createElement(n, { paser: 60 }), document.getElementById("timerbox")) } })
            }, changeImgcode: function () {
                e("#cpdycode").children("img").attr("src", "http://passport.zongheng.com/imgcapt?t=" + (new Date).getTime())
            }, render: function () {
                var e = this.state.comdis, a = this.state.smsdis;
                return "true" != this.props.isAuthor && this.props.name ? React.createElement("div", null, React.createElement("div", { className: "unlogtit" }, "申请作者!"), React.createElement("div", { className: "unloginfo" }, "您已是纵横的一员，马上申请作者，进行创作，开启您的作家之路。"), React.createElement("div", { className: "cl20" }), React.createElement("div", { className: "cl20" }), React.createElement("a", { className: "subbtn", onClick: this.regAuthor }, "立即申请")) : null == this.props.name ? React.createElement("div", { onClick: t.login, style: { cursor: "pointer" } }, React.createElement("div", { className: "unlogtit" }, "请先登录!"), React.createElement("div", { className: "unloginfo" }, "您现在还处于未登录状态，请先登录纵横中文网，才能进入作者专区创作。"), React.createElement("div", { className: "cl20" }), React.createElement("div", { className: "cl20" }), React.createElement("a", { className: "subbtn" }, "立即登录")) : React.createElement("react", null, React.createElement("form", { action: "/nau/login/pwd", className: "LoginBox", method: "post", id: "passLogin", style: { display: e }, onSubmit: i.login }, React.createElement("div", { className: "formtit" }, "输入登录作者专区密码"), React.createElement("div", { className: "mobilelnk f_ts" }, React.createElement("a", { href: "javascript:void(0);", onClick: this.changelogintype, "data-hook": "changeSmsLogin" }, React.createElement("span", { className: "icon icon-mobile" }), " 短信快捷登录")), React.createElement("div", { className: "iptwarp" }, React.createElement("div", { className: "iptline" }, React.createElement("div", { className: "ipt_box" }, React.createElement("span", { className: "icon icon-lock" }), React.createElement("input", { name: "pwd", type: "password", placeholder: "作者专区密码", "data-hook": "input", id: "authorPwd" }))), React.createElement("div", { className: "errorbox", "data-errcode": "100" }), React.createElement("div", { className: "iptline dycode", "data-hook": "dycode" }, React.createElement("div", { className: "ipt_box microbox fl" }, React.createElement("input", { name: "imgCode", style: { "margin-left": "10px" }, type: "text", placeholder: "请填写验证码", "data-hook": "input" })), React.createElement("div", { className: "ipt_imgcode fr", id: "cpdycode" }, React.createElement("img", { src: "http://passport.zongheng.com/imgcapt?t=1443073749072" }), React.createElement("a", { href: "javascript:;", onClick: this.changeImgcode }, "换一张")), React.createElement("div", { className: "cl" })), React.createElement("div", { className: "errorbox", "data-errcode": "112" })), React.createElement("div", { className: "cl10" }), React.createElement("div", { className: "form_sup f_ts" }, React.createElement("div", { className: "fl" }, React.createElement("a", { href: "javascript:void(0);", className: "f_gn regAuthor" }, "还未申请？立即申请作者")), React.createElement("div", { className: "fr" }, React.createElement("a", { href: "javascript:void(0);", onClick: this.forgetPass, className: "f_gy", style: { display: this.props.disforget } }, "忘记密码?"))), React.createElement("div", { className: "cl15" }), React.createElement("input", { type: "submit", className: "subbtn", "data-hook": "subbtn", value: "立即登录" })), React.createElement("form", { action: "/nau/login/mobile", className: "LoginBox", method: "post", id: "smsLogin", style: { display: a }, onSubmit: i.smslogin }, React.createElement("div", { className: "formtit" }, "短信快捷登录"), React.createElement("div", { className: "mobilelnk f_ts" }), React.createElement("div", { className: "iptwarp" }, React.createElement("div", { className: "iptline" }, React.createElement("div", { className: "ipt_box" }, React.createElement("span", { className: "icon icon-mobile" }), React.createElement("input", { type: "text", id: "cellnumber", name: "mobile", placeholder: "请输入手机号", "data-hook": "input" })), React.createElement("div", { className: "cl" })), React.createElement("div", { className: "errorbox", "data-errcode": "106" }), React.createElement("div", { className: "iptline" }, React.createElement("div", { className: "ipt_box shortbox fl" }, React.createElement("span", { className: "icon icon-lock" }), React.createElement("input", { name: "dyCode", id: "smscode", type: "text", placeholder: "动态密码", "data-hook": "input" })), React.createElement("div", { className: "ipt_btn fr", id: "timerbtn" }, React.createElement("input", { type: "button", value: "发送动态密码", onClick: this.getsmsCode })), React.createElement("div", { className: "ipt_btn fr", id: "timerbox" }), React.createElement("div", { className: "cl" })), React.createElement("div", { className: "errorbox", "data-hook": "sendcodeerr", "data-errcode": "111" })), React.createElement("div", { className: "cl10" }), React.createElement("div", { className: "form_sup f_ts" }, React.createElement("div", { className: "fl" }, React.createElement("a", { href: "javascript:void(0);", className: "f_gn regAuthor" }, "还未申请？立即申请作者")), React.createElement("div", { className: "fr" }, React.createElement("a", { href: "javascript:void(0);", onClick: this.changelogintype, className: "f_gy" }, "返回密码登录>>"))), React.createElement("div", { className: "cl15" }), React.createElement("input", { type: "submit", className: "subbtn", "data-hook": "subbtn", value: "立即登录" })))
            }
        }), n = React.createClass({
            displayName: "TimerBtn", getInitialState: function () {
                return { resendtime: this.props.paser }
            }, tick: function () {
                if (1 == this.state.resendtime) return clearInterval(this.interval), e("#timerbtn").show(), e("#timerbox").html("").hide(), !1; this.setState({ resendtime: this.state.resendtime - 1 })
            }, componentDidMount: function () {
                this.interval = setInterval(this.tick, 1e3)
            }, render: function () {
                return React.createElement("div", null, "重新发送(", this.state.resendtime, ")")
            }
        }); window.zhname || (window.zhname = null), React.render(React.createElement(r, { name: zhname, issms: e("body").attr("logtype"), isAuthor: e("body").attr("isAuthor") }), document.getElementById("formbox")), React.render(React.createElement(a, { name: zhname, isAuthor: e("body").attr("isAuthor") }), document.getElementById("loginalert")), e("[data-hook=logout]").click(function () { t.logout() })
});