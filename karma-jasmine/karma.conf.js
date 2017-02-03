module.exports = function(config) {
  config.set({
    basePath: '',
    frameworks: ['jasmine'],
    files: [
	
	 './node_modules/angular/angular.js',                             // angular
    './node_modules/angular-ui-router/release/angular-ui-router.js', // ui-router
    './node_modules/angular-mocks/angular-mocks.js',                 // loads our modules for tests
    './app/services/users/users.js',                                 // our Users factory
    './app/app.js', 
	'./app/services/users/users.spec.js'
    ],
    exclude: [
    ],
    preprocessors: {
    },
    reporters: ['progress'],
    port: 9876,
    colors: true,
    logLevel: config.LOG_INFO,
    autoWatch: true,
    browsers: ['Chrome'],
    singleRun: false,
    concurrency: Infinity
  })
}