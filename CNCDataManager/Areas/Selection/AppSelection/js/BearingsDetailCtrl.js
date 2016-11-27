﻿var BearingsDetailCtrl=angular.module("BearingsDetailCtrl",[]);
//直线导轨详情页控制器
BearingsDetailCtrl.controller("BearingsDetailCtrl",function($scope,$state,$stateParams,$http,$locals,$data){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	$scope.imgsrc="../../Areas/Selection/AppSelection/imgs/Bearings/"+$stateParams.type+".jpg";
	$scope.bearing={};
	$http({
		method:"GET",
		url:$data.http+$stateParams.type,
		params:{
			id:$stateParams.id
		}
	}).success(function(data){
		$scope.bearing=data;
	});
	$scope.nextStep=function(){
		$scope.bearing.img="Bearings.jpg";
		$locals.putObject($scope.FeedSystemType+"Bearings",$scope.bearing);
		$scope.$emit('ComponentChange',$scope.FeedSystemType+"Bearings");
		$state.go("FeedSystem.Coupling");
	};
	$scope.back=function(){
		$state.go("FeedSystem.Bearings");
	};
});