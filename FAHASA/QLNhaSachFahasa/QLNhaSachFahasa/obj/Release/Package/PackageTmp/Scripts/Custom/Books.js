function GetData() {
    var keywork = $('#txtSearchDataTable').val();
    dataSource = new kendo.data.DataSource({
        transport: {
            read: function (options) {
                $.ajax({
                    url: '/Book/GetList',
                    data: {
                        keywork: keywork,
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
    $("#frmCreateBook").validate({
        ignore: '',
        rules: {
            "TENSACH": {
                required: true
            },
            "TACGIA": {
                required: true
            },
            "NHAXUATBAN": {
                required: true,
            },
            "GIASACH": {
                required: true
            },
        },
        messages:
        {
            "TENSACH": {
                required: "Tên sách không được để trống."
            },
            "TACGIA": {
                required: "Tác giả không được để trống."
            },
            "NHAXUATBAN": {
                required: "Nhà xuất bản không được để trống."
            },
            "GIASACH": {
                required: "Giá sách không được để trống."
            },
        },
        success: function (error) {
            error.remove();
        }
    });
}
function itemClick(id) {
    $('#wndViewsContent').load("/Admin/Book/InfoBook?id=" + id, function () {
        $("#popupViewsWindows").data("kendoWindow").center().open().element.closest(".k-window").css({ top: 20 });
    });
}
function popupEditBook(id) {
    $('#wndEditContent').load("/Admin/Book/EditBook?id=" + id, function () {
        $("#popupEditWindows").data("kendoWindow").center().open().element.closest(".k-window").css({ top: 20 });
    });
}
function funcDeleteBook(id) {
    var Ok = confirm('Bạn có muốn xóa sách ' + id + "?");
    if (Ok)
        $.ajax({
            url: "/Book/Delete",
            data: { id: id },
            dataType: "json",
            type: "POST",
            success: function (response) {
                if (response.result == true) {
                    GetData();
                } else {
                    GetData();
                }
            },
        })
    else
        return false;
}