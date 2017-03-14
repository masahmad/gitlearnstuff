define(['underscore', 'jquery'], function(_u,q) {
  
  var showName = function(n) {
    var temp = _.template("Hello <%= name %>");
    q('#container').html(temp({name: n}));
  };
  return {
    showName: showName
  };
});