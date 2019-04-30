$(document).ready(function () {
    // dùng 1 mảng chứa danh sách BDS
    //var DS_BDS = [];
    //var DS_HINHANH = [];
    //var makv = 0;
    //var maloai = 0;
    //var page = 1;
    //var tongtrang;
    
    //LoadDuLieu(makv, maloai, page);

    // dùng phương thức ajax gọi lên server lấy dữ liệu

    // lấy danh sách bất động sản
    //function LoadDuLieu(makv, maloai, page) {        
    //    $.ajax({
    //        type: "POST",
    //        url: "trangchu.aspx/LoadDL",
    //        data: '{"makv":'+makv+',"maloai":'+maloai+',"page":'+page+'}',
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (data) {                
    //            DS_BDS = data.d;                
    //            HienThiDuLieu(page);
    //            console.log(DS_BDS);
    //        },
    //        error: function (er) { console.log(er) }
    //    });
    //}
    // lấy hình ảnh slide
    //function LoadHinhAnh(mabds) {
    //    $.ajax({
    //        type: "POST",
    //        url: "trangchu.aspx/LoadHinhAnh",
    //        data: '{"mabds":' + mabds + '}',
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (data) {
    //            DS_HINHANH = data.d;                
    //            HienThiSlide();
    //        },
    //        error: function (er) { console.log(er) }
    //    });
    //}

    // Kiểm tra đăng nhập
    function DangNhap(taikhoan, matkhau) {
        console.log(taikhoan);
        $.ajax({
            type: "POST",
            url: "Default.aspx/DangNhap",
            data: '{"taikhoan":"' + taikhoan + '","matkhau":"' + matkhau + '"}',
            contentType: "application/json; chatset=utf-8",
            dataType: "json",
            success: function (data) {
                var kq = data.d;
                if (kq == '1') {
                    var url = './admin/suaxoaBDS.aspx';
                    window.open(url, '_self');
                }
                else {
                    $(".thongbao_dn").removeClass("hide");
                }
                
            },
            error: function (er) {
                alert('Đăng nhập thất bại. Vui lòng thử lại');
            }
        });
    }

    // Hiển thị dữ liệu lên
    //function HienThiDuLieu(page) {
    //    tongtrang = DS_BDS[0].TongTrang;
    //    // Hiển thị dữ liệu
       
    //    var show = '';
    //    if (tongtrang > 0) {
    //        for (var i = 0; i < DS_BDS.length ; i++) {
    //            var show_item = '<div class="col-xs-12 col-sm-6 col-lg-3">';
    //            show_item += '<div class="card">';
    //            show_item += '<img class="card-img-top" src=' + DS_BDS[i].HinhAnh + ' alt="Card image">';
    //            show_item += '<div class="card-body card-title">';
    //            show_item += '<a href="./trangchu.aspx?mabds=' + DS_BDS[i].maBDS + '" class="tenbds" data-mabds = "' + DS_BDS[i].maBDS + '">' + DS_BDS[i].tenBDS + '</a>';
    //            show_item += '<p class="card-text">' + DS_BDS[i].DiaChi + '</p> ';
    //            show_item += '<span class="Gia">' + DS_BDS[i].Gia + '</span>';
    //            show_item += '</div></div></div>';
    //            show += show_item;
    //        }
    //    }
    //    $("#show").html(show);
        
    //    // Thực hiện phân trang
        
             
    //    var htmlphantrang = '';
    //    htmlphantrang += '<li class="mr-2"><a href="#" class="prev-page"><img src="./Images/prev.png" alt=""></a></li>';         
    //    if (page < 5)
    //    {
    //        if (tongtrang < 7) {
    //            for (var i = 1; i < tongtrang + 1; i++) {
    //                if (i == page)
    //                    htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum tranghientai" data-number = "' + i + '" >' + i + '</a></li>';
    //                else
    //                    htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum" data-number = "' + i + '">' + i + '</a></li>';
    //            }
    //        }
    //        else {
    //            for (var i = 1; i < 7; i++) {
    //                if (i == page)
    //                    htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum tranghientai" data-number = "' + i + '" >' + i + '</a></li>';
    //                else
    //                    htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum" data-number = "' + i + '">' + i + '</a></li>';
    //            }
    //            htmlphantrang += '<li class="mr-2"><a href="" class="no-drop">...</a></li>';
    //        }
    //    }
    //    else
    //    {           
    //        htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum" data-number = "1">1</a></li>';
    //        htmlphantrang += '<li class="mr-2"><a href="" class="no-drop">...</a></li>';
    //        var tutrang = parseInt(page) - 2;
    //        var dentrang = parseInt(page) + 3;
    //        if (dentrang < tongtrang)
    //        {                
    //            for (var i = tutrang; i < dentrang; i++)
    //            {
    //                if (i == page)
    //                    htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum tranghientai" data-number = "' + i + '">' + i + '</a></li>';
    //                else
    //                    htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum" data-number = "' + i + '">' + i + '</a></li>';
    //            }
    //            htmlphantrang += '<li class="mr-2"><a href="" class="no-drop">...</a></li>';
    //            htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum" data-number = "' + tongtrang + '">' + tongtrang + '</a></li>';
    //        }
    //        else
    //        {
                
    //            for (var i = parseInt(tongtrang) - 4; i <= tongtrang; i++)
    //            {
    //                if (i == page)
    //                    htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum tranghientai" data-number = "' + i + '">' + i + '</a></li>';
    //                else
    //                    htmlphantrang += '<li class="mr-2"><a href="#" class="pagenum" data-number = "' + i + '">' + i + '</a></li>';
    //            }
    //        }
    //    }
    //    htmlphantrang += '<li class="mr-2"><a href="#" class="next-page"><img src="./Images/next.png" alt=""></a></li>';
    //    $('#phantrang').html(htmlphantrang);
    //}

    // Load dữ liệu theo menu khu vực
    //$("body").delegate(".khuvuc", "click", function () {
    //    //ẩn trang chi tiết, hiện trang danh sách
    //    $("#loadsp").removeClass("hide");
    //    $("#trangchitiet").addClass("hide");
    //    // gán lại tiêu đề
    //    $(".hotnews-title").html($(this).attr("data-name"));
    //    // load dữ liệu
    //    makv = $(this).attr("data-makv");
    //    maloai = 0;
    //    page = 1;
    //    LoadDuLieu(makv, maloai, page);
    //})

    // Load dữ liệu theo loại
    //$("body").delegate(".loaibds", "click", function () {
    //    //ẩn trang chi tiết, hiện trang danh sách
    //    $("#loadsp").removeClass("hide");
    //    $("#trangchitiet").addClass("hide");
    //    // gán lại tiêu đề
    //    $(".hotnews-title").html($(this).attr("data-name"));
    //    // load dữ liệu
    //    maloai = $(this).attr("data-maloai");
    //    makv = 0;
    //    page = 1;
    //    LoadDuLieu(makv, maloai, page);
    //})

    // Xử lý nút phân trang
    //$("body").delegate(".pagenum", "click", function () {
    //    //event.preventDefault();
    //    page = $(this).attr("data-number");        
    //    LoadDuLieu(makv, maloai, page);
    //})

    //$("body").delegate(".next-page", "click", function () {
    //    // event.preventDefault();
    //    if (page < tongtrang) {
    //        page++;
    //        LoadDuLieu(makv, maloai, page);
    //    }
    //})

    //$("body").delegate(".prev-page", "click", function () {
    //    //event.preventDefault();        
    //    if(page > 1) {
    //        page--;
    //        LoadDuLieu(makv, maloai, page);
    //    }
    //})

    // Xử lý click trên menu
    $("body").delegate(".nav-link", "click", function () {
        //event.preventDefault();
        //alert('');
        $("#myMenu ul .active").removeClass("active");
        $(this).parent().addClass("active");
    })

    // Hiển thị chi tiết sản phẩm
    //$("body").delegate(".tenbds", "click", function () {
    //    $("#loadsp").addClass("hide");
    //    $("#trangchitiet").removeClass("hide");        
    //    var mabds = $(this).attr("data-mabds");
    //    LoadHinhAnh(mabds);
    //    for (var i = 0; i < DS_BDS.length; i++) {
    //        if (DS_BDS[i].maBDS == mabds) {
    //            $(".title").html(DS_BDS[i].tenBDS);
    //            console.log(DS_BDS[i].NoiDung);
    //            $(".noidung").html(DS_BDS[i].NoiDung);
    //            $(".diachi").html(DS_BDS[i].DiaChi);
    //            $("#giasp").html(DS_BDS[i].Gia);
    //        }
    //    }

    //})
    
    //function HienThiSlide() {
    //    var slidehtml = '';        
    //    for (var i = 0; i < DS_HINHANH.length; i++) {
    //        if (i == 0) {
    //            slidehtml += '<div class="carousel-item active">';
    //        }
    //        else {
    //            slidehtml += '<div class="carousel-item">';
    //        }
    //        slidehtml += '<img src="' + DS_HINHANH[i] + '"/></div>';
    //    }
    //    slidehtml += '<a href="#carousel-slider" data-slide="prev" class="carousel-control-prev">';
    //    slidehtml += '<span class="carousel-control-prev-icon"></span></a>';
    //    slidehtml += '<a href="#carousel-slider" data-slide="next" class="carousel-control-next">';
    //    slidehtml += '<span class="carousel-control-next-icon"></span></a>';        
    //    $("#slide").html(slidehtml);
    //}

    // Xử lý quay lại trang danh sách sản phẩm
    $("body").delegate(".hotnews-title", "click", function () {
        $("#loadsp").removeClass("hide");
        $("#trangchitiet").addClass("hide");
    })
    $("body").delegate(".back", "click", function () {
        $("#loadsp").removeClass("hide");
        $("#trangchitiet").addClass("hide");
    })

    // Xử lý đăng nhập
    $("#dangnhap").click(function (event) {
        event.preventDefault();
        var taikhoan = $("#taikhoan").val();
        var matkhau = $("#matkhau").val();
        var test = true;
        if (taikhoan == '') {
            $(".thongbao_tk").removeClass("hide");
            test = false;
        }
        else {
            $(".thongbao_tk").addClass("hide");
            test = true;
        }
        if (matkhau == '') {
            $(".thongbao_mk").removeClass("hide");
            test = false;
        }
        else {
            $(".thongbao_mk").addClass("hide");
            test = true;
        }
        if (!test) {
            return false;
        }
        else {
            DangNhap(taikhoan, matkhau);
        }
    })
})