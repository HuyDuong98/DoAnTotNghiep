function popupEditEmployee(id) {
    $('#wndEditContent').load("/Admin/Emloyee/EditEmloyee?id=" + id, function () {
        $("#popupEditWindows").data("kendoWindow").center().open().element.closest(".k-window").css({ top: 20 });
    });
}

function itemClick(id) {
    $('#wndViewsContent').load("/Admin/Emloyee/InfoEmployee?id=" + id, function () {
        $("#popupViewsWindows").data("kendoWindow").center().open().element.closest(".k-window").css({ top: 20 });
    });
}

function fnUpdateStatusEmp(id) {
    $.ajax({
        url: "/Emloyee/ChangeStatusEmployee",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (response) {
            if (response.status == true) {
                $("#status-" + id).text("Làm việc");
                $("#status-" + id).removeClass("status-inactive");
                $("#status-" + id).addClass("status-active");
                GetData();
            } else {
                $("#status-" + id).text("Thôi việc");
                $("#status-" + id).addClass("status-inactive");
                $("#status-" + id).removeClass("status-active");
                GetData();
            }
        },


    })
}

function GetData() {
    var keywork = $('#txtSearchDataTable').val();
    dataSource = new kendo.data.DataSource({
        transport: {
            read: function (options) {
                $.ajax({
                    url: '/Emloyee/GetList',
                    data: {
                        keywork: keywork,
                        status: $("#status-employee").data("kendoDropDownList").value(),
                    },
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
        pageSize: 25
    });
    GridData.setDataSource(dataSource);
}
function initValidation() {
    $("#frmCapNhatNhanVien").validate({
        ignore: '',
        rules: {
            "TENNV": {
                required: true
            },
            "EMAIL": {
                email: true,
                required: true
            },
            "USERNAMENV": {
                minlength: 6,
                maxlength: 20
            },
            "PASSWORDNV": {
                minlength: 6,
                maxlength: 20
            }
        },
        messages:
        {
            "TENNV": {
                required: "Họ khách hàng không được để trống."
            },
            "EMAIL": {
                email: "Email không đúng định dạng.",
                required: "Email không được để trống."
            },
            "USERNAMENV": {
                minlength: "Tên tài khoản ít nhất 6 ký tự",
                maxlength: "Tên tài khoản tối đa 20 ký tự"
            },
            "PASSWORDNV": {
                minlength: "Mật Khẩu ít nhất 6 ký tự",
                maxlength: "Mật khẩu tối đa 20 ký tự"
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
    $("#frmTaoMoiNhanVien").validate({
        ignore: '',
        rules: {
            "TenNV": {
                required: true
            },
            "Email": {
                email: true,
                required: true
            },
            "UserName": {
                minlength: 6,
                maxlength: 20,
                required: true
            },
            "Password": {
                minlength: 6,
                maxlength: 20,
                required: true
            },
             "ConfimPassword": {
                required: true
            }
        },
        messages:
        {
            "TenNV": {
                required: "Họ khách hàng không được để trống."
            },
            "Email": {
                email: "Email không đúng định dạng.",
                required: "Email không được để trống."
            },
            "UserName": {
                minlength: "Tên tài khoản ít nhất 6 ký tự.",
                maxlength: "Tên tài khoản tối đa 20 ký tự.",
                required: "Tên đăng nhập không được để trống."
            },
            "Password": {
                minlength: "Mật Khẩu ít nhất 6 ký tự.",
                maxlength: "Mật khẩu tối đa 20 ký tự.",
                required: "Mật khẩu không được để trống."
            },
              "ConfimPassword": {
                required: "Bạn chưa xác nhận mật khẩu."
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