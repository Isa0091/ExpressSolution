$(document).ready(function(){
	'use strict';
	
	scrollHeader();
	//efectoBanner();
	
	$(window).scroll(function() {
		scrollHeader();
	});
	
	/*Inicializar chosen para dar estilo a los select(dropdown)*/
	if($(".chosen").length){
		$(".chosen").chosen({
			disable_search_threshold: 5,
    		no_results_text: "No hay resultados",
    		width: "100%"
		});
	}
	
	$(".toggle-filtro a").click(function(e){
		e.preventDefault();
		$(this).parent().next(".box").slideToggle("300");
	});
	
	/*Funcionalidad del menu de categorias*/
	$(".toggle-dptos").click(function(e){
		e.preventDefault();
		$("#dptos .menu li").removeClass("active");
		$("body").toggleClass("open_departamentos");
	});
	
	$("#dptos .menu > li > a.open-panel").click(function(e){
		e.preventDefault();
		var theLI = $(this).parent("li");
		
		if(theLI.hasClass("active")){
			theLI.find(".menu li").removeClass("active");
			theLI.removeClass("active");
		}else{
			$("#dptos .menu.l2 > li").removeClass("active");
			theLI.siblings().removeClass("active");
			theLI.addClass("active");
		}
	});
	
	$("#dptos a.back.l2").click(function(e){
		e.preventDefault();
		$("#dptos .menu > li").removeClass("active");
	});
	
	$("#dptos a.back.l3").click(function(e){
		e.preventDefault();
		$("#dptos .menu.l2 > li").removeClass("active");
	});
	
	
	
	/**MENU MOVIL**/
	$(".toggle-menu2").click(function(e){
		e.preventDefault();
		$("body").toggleClass("open_menu2");
	});

	
	/*SLIDERS*/
	if($(".slider-conf1").length){
		$(".slider-conf1 .slider").slick({
			arrows: true,
			infinite: true,
			autoplay: true,
			autoplaySpeed: 4000,
			fade: true,
  			cssEase: 'linear',
			dots: false,
			prevArrow: '<a class="sld-arrow sld-prev"><i class="icon-left-open"></i></a>',
			nextArrow: '<a class="sld-arrow sld-next"><i class="icon-right-open"></i></a>'
		});
	}
	
	if($(".slider-conf2").length){
		$(".slider-conf2 .slider").slick({
			arrows: false,
			infinite: true,
			autoplay: true,
			autoplaySpeed: 2000,
			slidesToShow: 1,
			slidesToScroll: 1,
			dots: false,
			prevArrow: '<button type="button" class="slick-prev"><i class="icon-chevron-left"></i></button>',
			nextArrow: '<button type="button" class="slick-next"><i class="icon-chevron-right"></i></button>',
			centerMode: true,
			variableWidth: true
		});
	}
	
	if($(".slider-categorias").length){
		$(".slider-categorias .slider").slick({
			arrows: false,
			infinite: true,
			autoplay: true,
			autoplaySpeed: 2000,
			slidesToShow: 5,
			slidesToScroll: 1,
			dots: false,
			prevArrow: '<button type="button" class="slick-prev"><i class="icon-chevron-left"></i></button>',
			nextArrow: '<button type="button" class="slick-next"><i class="icon-chevron-right"></i></button>',
			responsive: [
				{
				  breakpoint: 1600,
				  settings: {
					slidesToShow: 4,
				  }
				},
				{
				  breakpoint: 1200,
				  settings: {
					slidesToShow: 3,
				  }
				},
				{
				  breakpoint: 768,
				  settings: {
					slidesToShow: 2,
				  }
				},
			]
		});
	}
	
	if($(".images-producto .big-slider").length){
		
		$(".images-producto .big-slider .slider").on('init reInit breakpoint beforeChange', function (event,slick,currentSlide,nextSlide) {
			var i = (nextSlide ? nextSlide : slick.currentSlide);
			//console.log("entrooo "+i);
			$(".images-producto .big-slider .pages").text(i+1 + ' / ' + slick.slideCount);
			
			if($(".images-producto .thumbs a[data-slide-number='"+i+"']").length){
				$(".images-producto .thumbs a").removeClass("active");
				$(".images-producto .thumbs a[data-slide-number='"+i+"']").first().addClass("active");
			}
		});
		
		
		
		$(".images-producto .big-slider .slider").slick({
			arrows: false,
			infinite: false,
			autoplay: false,
			autoplaySpeed: 4000,
			fade: true,
  			cssEase: 'linear',
			dots: false,
			slide: ".item",
			responsive: [
				{
				  breakpoint: 768,
				  settings: {
					arrows: true,
					autoplay: true,
				  }
				},
			]
		});
		
		
		$(".images-producto .thumbs a").click(function(e){
			e.preventDefault();
			var slideNumber = $(this).data("slide-number");
			$(".images-producto .thumbs a").removeClass("active");
			$(this).addClass("active");
			$(".images-producto .big-slider .slider").slick("slickGoTo",slideNumber);
		});
	}
	
    $(document).on("click", ".add-box .input .ctrl", function (e) {
        e.preventDefault();
        var theCtrl = $(this);
        var theInput = theCtrl.siblings("input").first();
        var theValue = parseInt(theInput.val());
        var maxValue = parseInt(theInput.data('maxcantidad'));
        var minValue = parseInt(theInput.data("mincantidad"));
        var newValue = theValue;

        var provoqueEvent = false;

        if (theCtrl.hasClass("up") && theValue < maxValue) {
            newValue = parseInt(theValue + 1);

            provoqueEvent = true;
        } else if (theCtrl.hasClass("down") && theValue > minValue) {
            newValue = parseInt(theValue - 1);
            provoqueEvent = true;
        }

        if (isNaN(newValue) || newValue < minValue) { newValue = minValue; }
        else if (newValue > maxValue) { newValue = maxValue; }

        theInput.val(newValue);

        if (provoqueEvent) {
            theInput.trigger("change");
        }

    });
    //$(".add-box .input .ctrl").click(function (e) {
    //    e.preventDefault();
    //    var theCtrl = $(this);
    //    var theInput = theCtrl.siblings("input").first();
    //    var theValue = parseInt(theInput.val());
    //    var maxValue = parseInt(theInput.data('maxcantidad'));
    //    var minValue = parseInt(theInput.data("mincantidad"));
    //    var newValue = theValue;

    //    var provoqueEvent = false;

    //    if (theCtrl.hasClass("up") && theValue < maxValue) {
    //        newValue = parseInt(theValue + 1);

    //        provoqueEvent = true;
    //    } else if (theCtrl.hasClass("down") && theValue > minValue) {
    //        newValue = parseInt(theValue - 1);
    //        provoqueEvent = true;
    //    }

    //    if (isNaN(newValue) || newValue < minValue) { newValue = minValue; }
    //    else if (newValue > maxValue) { newValue = maxValue; }

    //    theInput.val(newValue);

    //    if (provoqueEvent) {
    //        theInput.trigger("change");
    //    }
    //});
	
	
	/********************************************************/
	
	
	/*Mostrar ocultar form credito fiscal*/
	if($(".credito-fiscal").length){
		$("input.cbx-cfiscal").change(function(){
			cfiscal();
		});
		cfiscal();
	}
	
	function cfiscal(){
		var cbx = $("#cbx-cfiscal-si");
		if(cbx.is(":checked")){
			$("#form-cfiscal").slideDown(100);
		}else{
			$("#form-cfiscal").slideUp(100);
		}
	}
	
});
$(document).on("click", "#btnBorrarBusqueda", function(e) {
    e.preventDefault();
    $("#txtKeyWord").val("");
});
function scrollHeader() {
	'use strict';
	
	var header = $("body").first();
	
	var topH = 35;
	
	var scroll = $(window).scrollTop();
		
	if (scroll >= topH) {
		header.addClass("scrolled_window");
	} else {
		header.removeClass("scrolled_window");
	}
}

(function () {

    var _swal = window.swal;

    window.swal = function () {

        var previousWindowKeyDown = window.onkeydown;

        _swal.apply(this, Array.prototype.slice.call(arguments, 0));
        window.onkeydown = previousWindowKeyDown;

    };

})();

function IsNullOrEmpty(val) {
    if (val === undefined || val === "" || val === null )
        return true;

    return false;
}

function InitSelect2() {
    $('.select2').select2();
}