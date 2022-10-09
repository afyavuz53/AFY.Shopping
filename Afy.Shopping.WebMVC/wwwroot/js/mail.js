const _apikey = 'YWhtZXRtZXJ0YmlsYWw=';
const _path = 'https://sendmail.almancadaf.com/api/mail/Send';
const _mail = 'fehmi@desowa.com';
function sendmail(mailmodel, btnsend) {
    $.ajax({
        method: 'post',
        url: _path,
        headers: {
            "ApiKey": _apikey
        },
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(mailmodel),
        success: function (result) {
            if (result.isSuccess == true) {
                btnsend.html('Mesajınız İletildi.');
            } else {
                btnsend.html('Mesajınız İletilemedi.');
            }
        },
        error: function (data) {
            console.log(data)
            btnsend.html('Bir Sorun oluştu.');
        }
    })
}