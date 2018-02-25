function setCookie(key, value) {
    var date = new Date();
    date.setFullYear(date.getFullYear() + 1);
    debugger
    document.cookie = key + '=' + value + '; expires=' + date.toUTCString() + ';path=/';
}

function getCookie(key) {
    var value = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
    return value ? value[2] : null;
}


