﻿var SolidBallScrewNutPairsDetailCtrl=angular.module("SolidBallScrewNutPairsDetailCtrl",[]);
SolidBallScrewNutPairsDetailCtrl.controller("SolidBallScrewNutPairsDetailCtrl",function($scope,$http,$stateParams,$locals,$state,$data){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	$scope.ballscrew={};
	$http({
		method:"GET",
		url:$data.http+"SolidBallScrewNutPairs",
		params:{
			id:$stateParams.id
		}
	}).success(function(data){
		$scope.ballscrew=data;
	});
	$scope.nextStep=function(){
		$scope.ballscrew.img="Ballscrew.jpg";
		$locals.putObject($scope.FeedSystemType+"Ballscrew",$scope.ballscrew);
		$scope.$emit('ComponentChange',$scope.FeedSystemType+"Ballscrew");
		$state.go("FeedSystem.Bearings");
	};
	$scope.back=function(){
		$state.go("FeedSystem.SolidBallScrewNutPairs");
	}
});