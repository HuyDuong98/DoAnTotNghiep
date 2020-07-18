function initValidation() {
    $("#frmCapNhatKhachHang").validate({
        ignore: '',
        rules: {
            "HOKH": {
                required: true
            },
            "TENKH": {
                required: true
            },
            "EMAIL": {
                required: true,
                email: true
            },
            "DIACHI": {
                required: true
            },
            "USERNAME": {
                required: true,
                minlength: 6,
                maxlength: 20
            },
            "PASSWORD": {
                minlength: 6,
                maxlength: 20
            }
        },
        messages:
        {
            "HOKH": {
                required: "Họ khách hàng không được để trống."
            },
            "TENKH": {
                required: "Tên khách hàng không được để trống."
            },
            "EMAIL": {
                required: "Email không được để trống.",
                email: "Email không đúng định dạng."
            },
            "DIACHI": {
                required: "Địa chỉ không được để trống."
            },
            "USERNAME": {
                required: "Tên đăng nhập không được để trống.",
                minlength: "Tên tài khoản ít nhất 6 ký tự.",
                maxlength: "Tên tài khoản tối đa 20 ký tự."
            },
            "PASSWORD": {
                minlength: "Mật Khẩu ít nhất 6 ký tự.",
                maxlength: "Mật khẩu tối đa 20 ký tự."
            }
        },
        //errorPlacement: function (error) {
        //    var htmlFor = error[0].htmlFor;
        //    console.log(error[0]);
        //    $('span[for="' + htmlFor + '"]').each(function () {
        //        $(this).append(error);
        //    });
        //},
        success: function (error) {
            error.remove();
        }
    });
}
function popupEditCustomer(id) {
    $('#wndEditContent').load("/Admin/Customer/Edit?id=" + id, function () {
        $("#popupEditWindows").data("kendoWindow").center().open().element.closest(".k-window").css({ top: 20 });
    });
}
function GetData() {
    var keywork = $('#txtSearchDataTable').val();
    dataSource = new kendo.data.DataSource({
        transport: {
            read: function (options) {
                $.ajax({
                    url: '/Customer/GetListCustomer',
                    data: { keywork: keywork },
                    dataType: "json",
                    type: "POST",
                    success: function (result) {
                        options.success(result);
                    },
                    error: function (result) {
                        options.error(result);
                    }
                });
            }
        },
    });
    GridData.setDataSource(dataSource);
}
function funcDeleteCustomer(id) {
    var Ok = confirm('Bạn có muốn xóa khách hàng ' + id + "?");
    if (Ok)
        $.ajax({
            url: "/Customer/Delete",
            data: { id: id },
            dataType: "json",
            type: "POST",
            success: function () {
                GetData();
            },
        })
    else
        return false;
}