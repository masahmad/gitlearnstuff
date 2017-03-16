define(['jquery','methods'], function($,methods) {
  
  // private var
  
 var s;
var privateVar=123;
  
  
  
  NewsWidget = {
  settings: {
    numArticles: 5,
    articleList: $("#article-list"),
    moreButton: $("#load-button")
  },
  
  
  init: function() {
    s = this.settings;
    this.bindUIActions();
	//x=9;
  },
  
  bindUIActions: function() {
    s.moreButton.on("click", function() {
      NewsWidget.getMoreArticles(s.numArticles);
    });
  },
	  	  
	
  
  
   getMoreArticles: function(numToGet) {
    $(s.articleList).append('<br>hello');
    // using numToGet as param
  }
  
  
  ,getPrivateFN: function() { return privateVar;}
  
  
  ,getAjaxFN: function() {   return  methods.getAjax('http://localhost/playUX/api/playerdataapi'); }
  
  }
  
  return NewsWidget;
});