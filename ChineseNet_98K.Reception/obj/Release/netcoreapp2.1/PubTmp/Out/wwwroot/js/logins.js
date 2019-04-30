function HelloShit(i, t, e, r) {
    this.e = biFromHex(i),
        this.d = biFromHex(t),
        this.m = biFromHex(e),
        this.chunkSize = "number" != typeof r ? 2 * biHighIndex(this.m) : r / 8,
        this.radix = 16,
        this.barrett = new BarrettMu(this.m)
}
function hzasieckses(i, t, e, r) {
    var n, s, a, o, g, d, u, l, c, b = new Array, h = t.length, f = "";
    for (o = "string" == typeof e ? e == RSAAPP.NoPadding ? 1 : e == RSAAPP.PKCS1Padding ? 2 : 0 : 0, g = "string" == typeof r && r == RSAAPP.RawEncoding ? 1 : 0, 1 == o ? h > i.chunkSize && (h = i.chunkSize) : 2 == o && h > i.chunkSize - 11 && (h = i.chunkSize - 11), n = 0, s = 2 == o ? h - 1 : i.chunkSize - 1; n < h;)
        o ? b[s] = t.charCodeAt(n) : b[n] = t.charCodeAt(n), n++ , s--;
    for (1 == o && (n = 0), s = i.chunkSize - h % i.chunkSize; s > 0;) {
        if (2 == o) {
            for (d = Math.floor(256 * Math.random()); !d;)
                d = Math.floor(256 * Math.random()); b[n] = d
        }
        else
            b[n] = 0; n++ , s--
    }
    for (2 == o && (b[h] = 0, b[i.chunkSize - 2] = 2, b[i.chunkSize - 1] = 0), u = b.length, n = 0; n < u; n += i.chunkSize) {
        for (l = new BigInt, s = 0, a = n; a < n + i.chunkSize; ++s)
            l.digits[s] = b[a++], l.digits[s] += b[a++] << 8; c = i.barrett.powMod(l, i.e), f += 1 == g ? biToBytes(c) : 16 == i.radix ? biToHex(c) : biToString(c, i.radix)
    }
    return f
}
function decryptedString(i, t) {
    var e, r, n, s, a = t.split(" "), o = "";
    for (r = 0; r < a.length; ++r)
        for (s = 16 == i.radix ? biFromHex(a[r]) : biFromString(a[r], i.radix), e = i.barrett.powMod(s, i.d), n = 0; n <= biHighIndex(e); ++n)
            o += String.fromCharCode(255 & e.digits[n], e.digits[n] >> 8);
    return 0 == o.charCodeAt(o.length - 1) && (o = o.substring(0, o.length - 1)), o
}
function BarrettMu(i) {
    this.modulus = biCopy(i), this.k = biHighIndex(this.modulus) + 1;
    var t = new BigInt;
    t.digits[2 * this.k] = 1, this.mu = biDivide(t, this.modulus), this.bkplus1 = new BigInt, this.bkplus1.digits[this.k + 1] = 1, this.modulo = BarrettMu_modulo, this.multiplyMod = BarrettMu_multiplyMod, this.powMod = BarrettMu_powMod
}
function BarrettMu_modulo(i) {
    var t = biDivideByRadixPower(biMultiply(biDivideByRadixPower(i, this.k - 1), this.mu), this.k + 1), e = biSubtract(biModuloByRadixPower(i, this.k + 1), biModuloByRadixPower(biMultiply(t, this.modulus), this.k + 1));
    e.isNeg && (e = biAdd(e, this.bkplus1));
    for (var r = biCompare(e, this.modulus) >= 0; r;)
        e = biSubtract(e, this.modulus), r = biCompare(e, this.modulus) >= 0;
    return e
}
function BarrettMu_multiplyMod(i, t) {
    var e = biMultiply(i, t);
    return this.modulo(e)
}
function BarrettMu_powMod(i, t) {
    var e = new BigInt;
    e.digits[0] = 1;
    for (var r = i, n = t; 0 != (1 & n.digits[0]) && (e = this.multiplyMod(e, r)), 0 != (n = biShiftRight(n, 1)).digits[0] || 0 != biHighIndex(n);)
        r = this.multiplyMod(r, r);
    return e
}
function setMaxDigits(i) {
    maxDigits = i, ZERO_ARRAY = new Array(maxDigits);
    for (var t = 0; t < ZERO_ARRAY.length; t++)
        ZERO_ARRAY[t] = 0;
    bigZero = new BigInt, (bigOne = new BigInt).digits[0] = 1
}
function BigInt(i) {
    this.digits = "boolean" == typeof i && 1 == i ? null : ZERO_ARRAY.slice(0), this.isNeg = !1
}
function biFromDecimal(i) {
    for (var t, e = "-" == i.charAt(0), r = e ? 1 : 0; r < i.length && "0" == i.charAt(r);)
        ++r;
    if (r == i.length)
        t = new BigInt;
    else {
        var n = (i.length - r) % dpl10;
        for (0 == n && (n = dpl10), t = biFromNumber(Number(i.substr(r, n))), r += n; r < i.length;)
            t = biAdd(biMultiply(t, lr10), biFromNumber(Number(i.substr(r, dpl10)))), r += dpl10; t.isNeg = e
    }
    return t
}
function biCopy(i) {
    var t = new BigInt(!0);
    return t.digits = i.digits.slice(0), t.isNeg = i.isNeg, t
}
function biFromNumber(i) {
    var t = new BigInt;
    t.isNeg = i < 0, i = Math.abs(i);
    for (var e = 0; i > 0;)
        t.digits[e++] = i & maxDigitVal, i >>= biRadixBits;
    return t
}
function reverseStr(i) {
    for (var t = "", e = i.length - 1; e > -1; --e)
        t += i.charAt(e);
    return t
}
function biToString(i, t) {
    var e = new BigInt;
    e.digits[0] = t;
    for (var r = biDivideModulo(i, e), n = hexatrigesimalToChar[r[1].digits[0]]; 1 == biCompare(r[0], bigZero);)
        r = biDivideModulo(r[0], e), digit = r[1].digits[0], n += hexatrigesimalToChar[r[1].digits[0]];
    return (i.isNeg ? "-" : "") + reverseStr(n)
}
function biToDecimal(i) {
    var t = new BigInt;
    t.digits[0] = 10;
    for (var e = biDivideModulo(i, t), r = String(e[1].digits[0]); 1 == biCompare(e[0], bigZero);)
        e = biDivideModulo(e[0], t), r += String(e[1].digits[0]);
    return (i.isNeg ? "-" : "") + reverseStr(r)
}
function digitToHex(t) {
    var e = "";
    for (i = 0; i < 4; ++i)
        e += hexToChar[15 & t], t >>>= 4;
    return reverseStr(e)
}
function biToHex(i) {
    for (var t = "", e = (biHighIndex(i), biHighIndex(i)); e > -1; --e)
        t += digitToHex(i.digits[e]);
    return t
}
function charToHex(i) {
    return i >= 48 && i <= 57 ? i - 48 : i >= 65 && i <= 90 ? 10 + i - 65 : i >= 97 && i <= 122 ? 10 + i - 97 : 0
}
function hexToDigit(i) {
    for (var t = 0, e = Math.min(i.length, 4), r = 0; r < e; ++r)
        t <<= 4, t |= charToHex(i.charCodeAt(r));
    return t
}
function biFromHex(i) {
    for (var t = new BigInt, e = i.length, r = 0; e > 0; e -= 4, ++r)
        t.digits[r] = hexToDigit(i.substr(Math.max(e - 4, 0), Math.min(e, 4)));
    return t
}
function biFromString(i, t) {
    var e = "-" == i.charAt(0), r = e ? 1 : 0, n = new BigInt, s = new BigInt; s.digits[0] = 1;
    for (var a = i.length - 1; a >= r; a--) {
        n = biAdd(n, biMultiplyDigit(s, charToHex(i.charCodeAt(a)))), s = biMultiplyDigit(s, t)
    }
    return n.isNeg = e, n
}
function biToBytes(i) {
    for (var t = "", e = biHighIndex(i); e > -1; --e)
        t += digitToBytes(i.digits[e]);
    return t
}
function digitToBytes(i) {
    var t = String.fromCharCode(255 & i);
    i >>>= 8;
    return String.fromCharCode(255 & i) + t
}
function biDump(i) {
    return (i.isNeg ? "-" : "") + i.digits.join(" ")
}
function biAdd(i, t) {
    var e;
    if (i.isNeg != t.isNeg)
        t.isNeg = !t.isNeg, e = biSubtract(i, t), t.isNeg = !t.isNeg;
    else {
        e = new BigInt;
        for (var r, n = 0, s = 0; s < i.digits.length; ++s)
            r = i.digits[s] + t.digits[s] + n, e.digits[s] = 65535 & r, n = Number(r >= biRadix);
        e.isNeg = i.isNeg
    }
    return e
}
function biSubtract(i, t) {
    var e;
    if (i.isNeg != t.isNeg)
        t.isNeg = !t.isNeg, e = biAdd(i, t), t.isNeg = !t.isNeg;
    else {
        e = new BigInt;
        var r, n; n = 0;
        for (s = 0; s < i.digits.length; ++s)
            r = i.digits[s] - t.digits[s] + n, e.digits[s] = 65535 & r, e.digits[s] < 0 && (e.digits[s] += biRadix), n = 0 - Number(r < 0); if (-1 == n) {
                n = 0;
                for (var s = 0; s < i.digits.length; ++s)
                    r = 0 - e.digits[s] + n, e.digits[s] = 65535 & r, e.digits[s] < 0 && (e.digits[s] += biRadix), n = 0 - Number(r < 0);
                e.isNeg = !i.isNeg
            }
        else
            e.isNeg = i.isNeg
    } return e
}
function biHighIndex(i) {
    for (var t = i.digits.length - 1; t > 0 && 0 == i.digits[t];)
        --t;
    return t
}
function biNumBits(i) {
    var t, e = biHighIndex(i), r = i.digits[e], n = (e + 1) * bitsPerDigit;
    for (t = n; t > n - bitsPerDigit && 0 == (32768 & r); --t)
        r <<= 1;
    return t
}
function biMultiply(i, t) {
    for (var e, r, n, s = new BigInt, a = biHighIndex(i), o = biHighIndex(t), g = 0; g <= o; ++g) {
        for (e = 0, n = g, j = 0; j <= a; ++j, ++n)
            r = s.digits[n] + i.digits[j] * t.digits[g] + e, s.digits[n] = r & maxDigitVal, e = r >>> biRadixBits; s.digits[g + a + 1] = e
    }
    return s.isNeg = i.isNeg != t.isNeg, s
}
function biMultiplyDigit(i, t) {
    var e, r, n;
    result = new BigInt, e = biHighIndex(i), r = 0;
    for (var s = 0; s <= e; ++s)
        n = result.digits[s] + i.digits[s] * t + r, result.digits[s] = n & maxDigitVal, r = n >>> biRadixBits;
    return result.digits[1 + e] = r, result
}
function arrayCopy(i, t, e, r, n) {
    for (var s = Math.min(t + n, i.length), a = t, o = r; a < s; ++a, ++o)
        e[o] = i[a]
}
function biShiftLeft(i, t) {
    var e = Math.floor(t / bitsPerDigit), r = new BigInt; arrayCopy(i.digits, 0, r.digits, e, r.digits.length - e);
    for (var n = t % bitsPerDigit, s = bitsPerDigit - n, a = r.digits.length - 1, o = a - 1; a > 0; --a, --o)
        r.digits[a] = r.digits[a] << n & maxDigitVal | (r.digits[o] & highBitMasks[n]) >>> s; return r.digits[0] = r.digits[a] << n & maxDigitVal, r.isNeg = i.isNeg, r
}
function biShiftRight(i, t) {
    var e = Math.floor(t / bitsPerDigit), r = new BigInt;
    arrayCopy(i.digits, e, r.digits, 0, i.digits.length - e);
    for (var n = t % bitsPerDigit, s = bitsPerDigit - n, a = 0, o = a + 1; a < r.digits.length - 1; ++a, ++o)
        r.digits[a] = r.digits[a] >>> n | (r.digits[o] & lowBitMasks[n]) << s;
    return r.digits[r.digits.length - 1] >>>= n, r.isNeg = i.isNeg, r
}
function biMultiplyByRadixPower(i, t) {
    var e = new BigInt;
    return arrayCopy(i.digits, 0, e.digits, t, e.digits.length - t), e
}
function biDivideByRadixPower(i, t) {
    var e = new BigInt;
    return arrayCopy(i.digits, t, e.digits, 0, e.digits.length - t), e
}
function biModuloByRadixPower(i, t) {
    var e = new BigInt;
    return arrayCopy(i.digits, 0, e.digits, 0, t), e
}
function biCompare(i, t) {
    if (i.isNeg != t.isNeg)
        return 1 - 2 * Number(i.isNeg);
    for (var e = i.digits.length - 1; e >= 0; --e)
        if (i.digits[e] != t.digits[e])
            return i.isNeg ? 1 - 2 * Number(i.digits[e] > t.digits[e]) : 1 - 2 * Number(i.digits[e] < t.digits[e]); return 0
}
function biDivideModulo(i, t) {
    var e, r, n = biNumBits(i), s = biNumBits(t), a = t.isNeg;
    if (n < s)
        return i.isNeg ? (e = biCopy(bigOne), e.isNeg = !t.isNeg, i.isNeg = !1, t.isNeg = !1, r = biSubtract(t, i), i.isNeg = !0, t.isNeg = a) : (e = new BigInt, r = biCopy(i)), new Array(e, r);
    e = new BigInt, r = i;
    for (var o = Math.ceil(s / bitsPerDigit) - 1, g = 0; t.digits[o] < biHalfRadix;)
        t = biShiftLeft(t, 1), ++g, ++s, o = Math.ceil(s / bitsPerDigit) - 1; r = biShiftLeft(r, g), n += g;
    for (var d = Math.ceil(n / bitsPerDigit) - 1, u = biMultiplyByRadixPower(t, d - o); -1 != biCompare(r, u);)
        ++e.digits[d - o], r = biSubtract(r, u);
    for (var l = d; l > o; --l) {
        var c = l >= r.digits.length ? 0 : r.digits[l], b = l - 1 >= r.digits.length ? 0 : r.digits[l - 1], h = l - 2 >= r.digits.length ? 0 : r.digits[l - 2], f = o >= t.digits.length ? 0 : t.digits[o], m = o - 1 >= t.digits.length ? 0 : t.digits[o - 1]; e.digits[l - o - 1] = c == f ? maxDigitVal : Math.floor((c * biRadix + b) / f);
        for (var p = e.digits[l - o - 1] * (f * biRadix + m), v = c * biRadixSquared + (b * biRadix + h); p > v;)
            --e.digits[l - o - 1], p = e.digits[l - o - 1] * (f * biRadix | m), v = c * biRadix * biRadix + (b * biRadix + h); (r = biSubtract(r, biMultiplyDigit(u = biMultiplyByRadixPower(t, l - o - 1), e.digits[l - o - 1]))).isNeg && (r = biAdd(r, u), --e.digits[l - o - 1])
    }
    return r = biShiftRight(r, g), e.isNeg = i.isNeg != a, i.isNeg && (e = a ? biAdd(e, bigOne) : biSubtract(e, bigOne), t = biShiftRight(t, g), r = biSubtract(t, r)), 0 == r.digits[0] && 0 == biHighIndex(r) && (r.isNeg = !1), new Array(e, r)
}
function biDivide(i, t) {
    return biDivideModulo(i, t)[0]
}
function biModulo(i, t) {
    return biDivideModulo(i, t)[1]
}
function biMultiplyMod(i, t, e) {
    return biModulo(biMultiply(i, t), e)
}
function biPow(i, t) {
    for (var e = bigOne, r = i; 0 != (1 & t) && (e = biMultiply(e, r)), 0 != (t >>= 1);)
        r = biMultiply(r, r);
    return e
}
function biPowMod(i, t, e) {
    for (var r = bigOne, n = i, s = t; 0 != (1 & s.digits[0]) && (r = biMultiplyMod(r, n, e)), 0 != (s = biShiftRight(s, 1)).digits[0] || 0 != biHighIndex(s);)
        n = biMultiplyMod(n, n, e);
    return r
}
var RSAAPP = {};
RSAAPP.NoPadding = "NoPadding", RSAAPP.PKCS1Padding = "PKCS1Padding", RSAAPP.RawEncoding = "RawEncoding", RSAAPP.NumericEncoding = "NumericEncoding";
var maxDigits, ZERO_ARRAY, bigZero, bigOne, biRadixBase = 2, biRadixBits = 16, bitsPerDigit = biRadixBits, biRadix = 65536, biHalfRadix = biRadix >>> 1, biRadixSquared = biRadix * biRadix, maxDigitVal = biRadix - 1, maxInteger = 9999999999999998; setMaxDigits(20);
var dpl10 = 15, lr10 = biFromNumber(1e15), hexatrigesimalToChar = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"), hexToChar = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f"), highBitMasks = new Array(0, 32768, 49152, 57344, 61440, 63488, 64512, 65024, 65280, 65408, 65472, 65504, 65520, 65528, 65532, 65534, 65535), lowBitMasks = new Array(0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535);
$(function () {
    function i(i, t) {
        if (void 0 != i && "" != i && "1" != n) {
            var e = (new Date).getTime(), r = t ? "/prelogincheck.do" : "/preregcheck.do";
            $.ajax({
                type: "post",
                url: r,
                data: { tk: TK, unam: i, t: e },
                dataType: "json",
                error: function () { },
                success: function (i) {
                    if (i && 1 == i.code) {
                        var t = "https://passport.zongheng.com/passimg?captkey=" + i.data.captkey + "&t=" + Math.random() || "";
                        $(".error-more").show().find(".changecapt").attr({ src: t, "data-src": t }), o = !0
                    }
                    else
                        o = !1, $(".error-more").hide();
                    u = i.data.captkey || ""
                }
            })
        }
    }
    function t(i) {
        i = i || "出错啦！", $(".login-tips").find(".error-tip").show().html(i)
    }
    function e() {
        $(".login-tips").find(".error-tip").hide()
    }
    var r = function (i, t) {
        var e = document.getElementsByTagName("head")[0], r = document.createElement("script");
        r.setAttribute("type", "text/javascript"), r.setAttribute("src", i), e.appendChild(r), r.onload = function () { "function" == typeof t && t() }
    }, n = $("body").attr("data-cpt3");
    if ("1" == n) {
        window.NVC_Opt = {
            appkey: $("body").attr("data-cpt3app"),
            scene: $("body").attr("data-cpt3scene"),
            renderTo: "#captcha",
            trans: { key1: "code0", nvcCode: 200 },
            elements: [
                '//img.alicdn.com/tfs/TB17cwllsLJ8KJjy0FnXXcFDpXa-50-74.png',
                '//img.alicdn.com/tfs/TB17cwllsLJ8KJjy0FnXXcFDpXa-50-74.png'
            ],
            bg_back_prepared: '//img.alicdn.com/tps/TB1skE5SFXXXXb3XXXXXXXXXXXX-100-80.png',
            bg_front: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABQCAMAAADY1yDdAAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAAADUExURefk5w+ruswAAAAfSURBVFjD7cExAQAAAMKg9U9tCU+gAAAAAAAAAIC3AR+QAAFPlUGoAAAAAElFTkSuQmCC',
            obj_ok: '//img.alicdn.com/tfs/TB1rmyTltfJ8KJjy0FeXXXKEXXa-50-74.png',
            bg_back_pass: '//img.alicdn.com/tfs/TB1KDxCSVXXXXasXFXXXXXXXXXX-100-80.png',
            obj_error: '//img.alicdn.com/tfs/TB1q9yTltfJ8KJjy0FeXXXKEXXa-50-74.png',
            bg_back_fail: '//img.alicdn.com/tfs/TB1w2oOSFXXXXb4XpXXXXXXXXXX-100-80.png',
            upLang: {
                "cn": {
                    _ggk_guide: "请摁住鼠标左键，刮出两面盾牌",
                    _ggk_success: "恭喜您成功刮出盾牌<br/>继续下一步操作吧",
                    _ggk_loading: "加载中",
                    _ggk_fail: ['呀，盾牌不见了<br/>请', "javascript:noCaptcha.reset()", '再来一次', '或', "http://survey.taobao.com/survey/QgzQDdDd?token=%TOKEN", '反馈问题'],
                    _ggk_action_timeout: ['我等得太久啦<br/>请', "javascript:noCaptcha.reset()", '再来一次', '或', "http://survey.taobao.com/survey/QgzQDdDd?token=%TOKEN", '反馈问题'],
                    _ggk_net_err: ['网络实在不给力<br/>请', "javascript:noCaptcha.reset()", '再来一次', '或', "http://survey.taobao.com/survey/QgzQDdDd?token=%TOKEN", '反馈问题'],
                    _ggk_too_fast: ['您刮得太快啦<br/>请', "javascript:noCaptcha.reset()", '再来一次', '或', "http://survey.taobao.com/survey/QgzQDdDd?token=%TOKEN", '反馈问题']
                }
            }
        };
        var s = {
            ispass: !1,
            sig: null,
            sessionid: null,
            token: NVC_Opt.token
        };
        r("//g.alicdn.com/sd/nvc/1.1.112/guide.js", function () { }),
            r("//g.alicdn.com/sd/smartCaptcha/0.0.1/index.js", function () {
                new smartCaptcha({
                    renderTo: "#aliscode",
                    width: 350,
                    height: 32,
                    default_txt: '点击按钮开始智能验证',
                    success_txt: '验证成功',
                    fail_txt: '验证失败，请在此点击按钮刷新',
                    scaning_txt: '智能检测中',
                    success: function (i) {
                        s.token = NVC_Opt.token,
                            s.sessionid = i.sessionId,
                            s.sig = i.sig,
                            s.ispass = !0
                    }
                }).init()
            })
    }
    var a = /^1\d{10}$/, o = !1, g = !1, d = !1;
    $("#telphone").blur(function () {
        var i = $(this), r = $.trim(i.val());
        if ("" != r)
            if (a.test(r)) {
                e(), $("#yzm").removeAttr("readonly");
                var n = (new Date).getTime();
                $.ajax({
                    type: "post",
                    url: "/preregcheck.do",
                    data: {  unam: r, t: n },
                    dataType: "json",
                    error: function () { d = !0 },
                    success: function (i) {
                        if (d = !0, i && 1 == i.code) {
                            var t = "https://passport.zongheng.com/passimg?captkey=" + i.data.captkey + "&t=" + Math.random() || ""; $(".error-more").show().find(".changecapt").attr({ src: t, "data-src": t }), $("#imgyzm").select(), o = !0
                        }
                        else
                            o = !1, $(".error-more").hide(); u = i.data.captkey || ""
                    }
                })
            }
            else t("手机号格式错误")
    }).blur(function () { d = !1 }),
        $("#telphone,#yzm,#imgyzm2,#imgyzm").focus(function () { e() }),
        $(".login-style").find("span").click(function () {
            if (!$(this).hasClass("login-s-active")) {
                if ($(".error-more").hide(), $(this).hasClass("login-s-msg"))
                    return $(".login-box").eq(0).show().siblings(".login-box").hide(), $(this).addClass("login-s-active").siblings().removeClass("login-s-active"), e(), void $("#telphone").blur();
                $(this).hasClass("login-s-user") && ($(".login-box").eq(1).show().siblings(".login-box").hide(), $(this).addClass("login-s-active").siblings().removeClass("login-s-active"), $("#username").blur(), e())
            }
        }),
        $(".checkbox").find("label").click(function () { $(this).find("span").hasClass("icon-checked") ? $(this).find("span").removeClass("icon-checked") : $(this).find("span").addClass("icon-checked") });
    var u;
    $(".btn-submit").click(function () {
        var r = {};
        if ($(this).hasClass("submit-phone")) {
            if (r.unam = $.trim($("#telphone").val()), r.pwd = $.trim($("#yzm").val()), r.capt = $.trim($("#imgyzm").val()), "" == r.unam)
                return void t("手机号不能为空");
            if (!a.test(r.unam))
                return void t("手机号格式错误");
            if ("" == r.pwd)
                return void t("短信验证码不能为空")
        }
        else {
            if (r.tye = 1, r.unam = $.trim($("#username").val()), r.pwd = $("#password").val(), "1" == n ? (r.sessionid = s.sessionid, r.sig = s.sig, r.scene = NVC_Opt.scene, r.token = s.token) : r.capt = $.trim($("#imgyzm2").val()), s && 0 == s.ispass && "1" == n) return t("请先通过人机验证"), void ($.browser.msie && !0 === $.browser.msie && parseInt($.browser.version) < 9 && t("您的浏览器可能不支持人机验证，请使用ie9以上版本或者Chrome"));
            if ("" == r.unam)
                return void t("用户名不能为空");
            if ("" == r.pwd)
                return void t("密码不能为空");
            if (o && "" == r.capt)
                return void t("验证码不能为空")
        } r.captkey = u, function (r) {
            e();
            var n = $.extend({ tye: 0, plat: 0 }, r);
            if (1 == n.tye) {
                setMaxDigits(130);
                //var s = new HelloShit(RSA_e, "", RSA_m);
                //n.pwd = hzasieckses(s, encodeURIComponent(n.pwd))
            }
            else if (!g)
                return void t("请先获取短信验证码");
            $.ajax({
                type: "post",
                url: "/Users/Login",
                data: n,
                dataType: "json",
                error: function () { t("服务器出错，请您重试!") },
                success: function (e) {
                    if (e)
                        switch (e) {
                            case 1: location.href = comeBackUrl,
                                $(".checkbox").eq(n.type).find(".icon-checked").size() > 0 ? 0 == n.tye && CookieUtil.setCookie({ name: "loginphone", value: n.unam, expires: 31536e3 }) : 0 == n.tye && CookieUtil.setCookie({ name: "loginphone", value: "", expires: -1 }); break;
                            case 2: t(r = e.msg || "用户名或者密码错误"), i(n.unam, n.tye); break;
                            case 9002: location.reload(); break;
                            case 2300: t(r = e.msg || "验证码不能为空"), i(n.unam, n.tye); break;
                            case 2302: t(r = e.msg || "验证码错误"), i(n.unam, n.tye); break;
                            case 2201: t(r = e.msg || "验证码已经过期，请重新发送"), $("#yzm").val(""), i(n.unam, n.tye); break;
                            default: var r = e.msg || "出错啦，请您刷新后重试"; t(r), i(n.unam, n.tye)
                        }
                    else t("出现未知错误，请您重试!")
                }
            })
        }(r)
    }),
        $("#username").blur(function () { i($.trim($(this).val()), 1) }), $(".changecapt").click(function () {
            var i = (new Date).getTime();
            $(this).attr("src", $(this).attr("data-src") + "&t=" + i)
        }),
        function () {
            var i = CookieUtil.getCookie("loginphone");
            i && $("#telphone").val(i)
        }();
    var l = null, c = 60;
    $(".sentphonecapt").click(function () {
        var i = $(this);
        if (i.hasClass("sentend")) t("发送太频繁啦，请您" + c + "秒后再试");
        else {
            var e = $.trim($("#telphone").val()), r = $.trim($("#imgyzm").val()); "" != e ? a.test(e) ? o && "" == r ? t("图片验证码不能为空") : d && $.ajax({
                type: "post",
                url: "/sendloginsms.do",
                data: { phone: e, captkey: u, capt: r },
                dataType: "json",
                error: function () { t("发送手机验证码失败！"), i.html("重新发送"), g = !1, clearInterval(l) },
                success: function (e) {
                    if (e && 1 == e.code)
                        i.html("发送成功(" + c + ")").addClass("sentend"), g = !0, l = setInterval(function () { c -= 1, i.html("发送成功(" + c + ")"), 0 == c && (clearInterval(l), c = 60, i.html("发送验证码").removeClass("sentend")) }, 1e3), u = e.data.captkey || "";
                    else if (e && 9002 == e.code)
                        location.reload();
                    else {
                        g = !1; t(e.msg || "发送手机验证码失败！")
                    }
                }
            }) : t("手机号格式错误") : t("手机号不能为空")
        }
    }), $(".login-box").find(".login-text").keydown(function (i) { 13 == (i || window.event).keyCode && $(this).parents(".login-box").find(".btn-submit").click() })
});