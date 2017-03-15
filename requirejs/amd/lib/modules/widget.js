define(['jquery','methods'], function($,methods) {
  
  
  var s,
  
  NewsWidget = {
  settings: {
    numArticles: 5,
    articleList: $("#article-list"),
    moreButton: $("#load-button")
  },
  
  
  init: function() {
    s = this.settings;
    this.bindUIActions();
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
  
  }
  
  return NewsWidget;
});