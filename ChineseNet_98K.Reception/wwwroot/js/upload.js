$(function (){
	var auForm=$(".au_c_form");
	var uploadArea=auForm.find(".uploadarea");
	var upLoaderror=auForm.find(".uploaderror");
	var upLoding=auForm.find(".uploading");
	var book_ID=$("body").attr("bookid") || "";
	//实例化一个plupload上传对象
	var uploader = new plupload.Uploader({
		runtimes : 'html5,silverlight,html4',//
		browse_button : 'uploadbtn', //触发文件选择对话框的按钮，为那个元素id
        url:'/AuthorLR/CreatWork', //服务器端的上传页面地址
		silverlight_xap_url : 'http://static.zongheng.com/author/v2015/js/load/Moxie.xap', //silverlight文件，当需要使用silverlight方式进行上传时需要配置该
		file_data_name:"coverFile",
		filters:{
			mime_types:[{title:"images",extensions:"jpg,jpeg"}],
			max_file_size : '100kb',
			prevent_duplicates:false//允许选取重复图片
		},
		multipart_params:{bookId:book_ID}
	});
	    
	//在实例对象上调用init()方法进行初始化
	uploader.init();
	setTimeout(function (){
		if($("#uploadbtn").is(":hidden")) uploader.destroy();
	},1000)
	/*选择图片进行上传*/
	uploader.bind('FilesAdded',function(uploader,files){
		uploader.start();//执行上传操作
		for(var i = 0, len = files.length; i<len; i++){
			var file_name = files[i].name; //文件名
			//构造html来更新UI
			!function(i){
				previewImage(files[i],function(imgsrc){
					upLoding.find("img").attr("src",imgsrc);
					uploadArea.show();
				})
		    }(i);
		}
		
	});
	uploader.bind('UploadProgress',function(uploader,files){
		//上传到服务器的过程进行监控
		uploadArea.show();
		var percent=files.percent+"%";
		upLoaderror.fadeOut().siblings(".uploading").fadeIn();
		upLoding.find(".auloading").show().css("width",percent);
	});
	/*图片上传完成*/
	uploader.bind("FileUploaded",function (uploader,file,responseObject){
		uploadArea.show();
		upLoding.find(".auloading").hide().siblings(".savebook").show();
	})
	/*上传出错*/
	uploader.bind('Error',function (uploader,err){
		var errortip="图片大小不要超过100K";
		if(err.code==-600){//超过尺寸
			upLoding.hide();
		}		
		else if(err.code==-601){
			errortip="格式不符合封面要求";
		}
		else{
			errortip="图片上传失败";
		}
		uploadArea.show();
		upLoaderror.find(".error_font").html(errortip);
		upLoaderror.fadeIn().siblings(".uploading").fadeOut();
		//uploader.start();//重新绑定上传
	})
	/*获取服务器返回数据*/
	uploader.bind("FileUploaded",function(up,file,result){
		var data=eval("("+result.response+")");
		var code=data.code;
		if(code==200){
			var booksrc=data.result;
			auForm.attr({"code":code,"coverFile":booksrc});
		}
		else{
			upLoaderror.find(".error_font").html(data.message);
			upLoaderror.fadeIn().siblings(".uploading").fadeOut();
			auForm.attr({"code":code});
		}
		uploadArea.show();
	})
	
	/*获取图片上传后的路径，用来显示*/
	function previewImage(file,callback){//file为plupload事件监听函数参数中的file对象,callback为预览图片准备完成的回调函数
		if(!file || !/image\//.test(file.type)) return; //确保文件是图片
		
		if(file.type=='image/gif'){//gif使用FileReader进行预览,因为mOxie.Image只支持jpg和png
			var fr = new mOxie.FileReader();
			fr.onload = function(){
				callback(fr.result);
				fr.destroy();
				fr = null;
			}
			fr.readAsDataURL(file.getSource());
		}else{
			var preloader = new mOxie.Image();
			preloader.onload = function() {
				preloader.downsize( 160, 212 );//先压缩一下要预览的图片
				var imgsrc = preloader.type=='image/jpeg' ? preloader.getAsDataURL('image/jpeg',80) : preloader.getAsDataURL(); //得到图片src,实质为一个base64编码的数据
				callback && callback(imgsrc); //callback传入的参数为预览图片的url
				preloader.destroy();
				preloader = null;
			};
			preloader.load( file.getSource() );
		}	
	}
	/*保存封面*/
	auForm.find(".savebook").click(function (){
		var t=$(this);
		if(t.attr("code")==200){
			var src=t.attr("coverFile")
			t.hide();
			auForm.find("input[name='coverFile']").val(src);
			
		}
		else{
			publicDialog("保存封面","封面上传失败无法保存",0);
		}
	})
})