﻿var services=angular.module("services",[]);

//service自定义服务保存可能变动的网址前缀
services.service("$data", function(){
	this.http="http://cncdataapi.azurewebsites.net/api/cncdata/";
	//this.http="http://localhost:8011/api/cncdata/";
});

//value自定义服务保存计算中没有提供参数时的默认值
services.value("$default",{
	guideFriction:0.003,   //导轨库伦摩擦系数
	guideSealingResistance:100,   //滚动导轨的密封阻力
	guideType:"滚动导轨",
	ballscrewShaftDia:24,   //滚珠丝杠联轴器配合轴孔直径
	ballscrewMaxSpeed:8000,   //滚珠丝杠极限转速
	ballscrewAccuracyClass:1,   //滚珠丝杠精度等级
	ballscrewLead:5,   //滚珠丝杠计算结果导程
	ballscrewTorque:2,   //滚珠丝杠计算结果等效负载转矩
	ballscrewNominalDiameter_d0:30,
	ballscrewLength:1000,
});

services.value("$constants",{
	IronDensity:0.0078   //钢铁密度，单位是kg/cm^3
});


//service自定义服务取出和保存数据到localstorage中
services.service("$locals",["$window",function($window){
	this.put=function(key,value){
		$window.localStorage.setItem(key,value);
	};
	this.get=function(key){
		return $window.localStorage.getItem(key)||"";
	};
	this.putObject=function(key,value){
		return $window.localStorage.setItem(key,JSON.stringify(value));
	};
	this.getObject=function(key){
		return JSON.parse($window.localStorage.getItem(key));
	};
	this.clear=function(){
		$window.localStorage.clear();
	}
}]);

services.service('$fly',function(){
	this.start=function(event){
		var flyer=$('<img class="u-flyer" src="../../Areas/Selection/AppSelection/imgs/gear-icon.png">');
		flyer.fly({
			start:{
				left:event.pageX,
				top:event.pageY-document.body.scrollTop,
			},
			end:{
				left:$(window).width(),
				top:$(window).height()/2,
				width:0,
				height:0,
			},
			onEnd:function(){
				this.destory();
			}
		});
	};
});