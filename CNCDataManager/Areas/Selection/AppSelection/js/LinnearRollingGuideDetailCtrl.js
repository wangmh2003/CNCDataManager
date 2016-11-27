var LinnearRollingGuideDetailCtrl=angular.module("LinnearRollingGuideDetailCtrl",[]);
//直线导轨详情页控制器
LinnearRollingGuideDetailCtrl.controller("LinnearRollingGuideDetailCtrl",function($scope,$state,$stateParams,$http,$locals,$data){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	$scope.guid={};
	$http({
		method:"GET",
		url:$data.http+"LineRollingGuides",
		params:{
			id:$stateParams.id
		}
	}).success(function(data){
		$scope.guid=data;
	});
	$scope.nextStep=function(){
		$scope.guid.img="Guide.jpg";
		$locals.putObject($scope.FeedSystemType+"Guide",$scope.guid);
		$scope.$emit('ComponentChange',$scope.FeedSystemType+"Guide");
		$state.go("FeedSystem.SolidBallScrewNutPairs");
	};
	$scope.back=function(){
		$state.go("FeedSystem");
	};
});