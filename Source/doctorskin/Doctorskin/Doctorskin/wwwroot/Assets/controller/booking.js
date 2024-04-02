var booKing = {
    init: function () {
        $('#btnBooking').click(function () {
            $.ajax({
                url: '/Booking/SubBooking',
                type: 'post',
                dataType: 'json',
                data: $('#frmBookings').serialize(),
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        setTimeout(function () {
                            location.reload();
                        }, 1500);
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    }
}
$(document).ready(function () {
    booKing.init();
});