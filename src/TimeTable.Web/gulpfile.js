/// <binding AfterBuild='inject:index' />
"use strict";

var gulp = require("gulp"),
    series = require('stream-series'),
    inject = require('gulp-inject'),
    wiredep = require('wiredep').stream;

var webroot = "./wwwroot/";

var paths = {
    ngModule: webroot + "app/**/*.module.js",
    ngRoute: webroot + "app/**/*.route.js",
    ngController: webroot + "app/**/*.controller.js",
    script: webroot + "scripts/**/*.js",
    style: webroot + "styles/**/*.css"
};

gulp.task('inject:index', function () {
    var moduleSrc = gulp.src(paths.ngModule, { read: false });
    var routeSrc = gulp.src(paths.ngRoute, { read: false });
    var controllerSrc = gulp.src(paths.ngController, { read: false });
    var scriptSrc = gulp.src(paths.script, { read: false });
    var styleSrc = gulp.src(paths.style, { read: false });

    gulp.src('./Views/Shared/_Layout.cshtml')
        .pipe(wiredep({
            optional: 'configuration',
            goes: 'here',
            ignorePath: '../../wwwroot/',
            fileTypes: {
                html: {
                    detect: {
                        js: /<script.*src=['"]([^'"]+)/gi,
                        css: /<link.*href=['"]([^'"]+)/gi
                    },
                    replace: {
                        js: '<script src="~/{{filePath}}"></script>',
                        css: '<link rel="stylesheet" href="~/{{filePath}}" />'
                    }
                },
            }
        }))
        .pipe(inject(series(scriptSrc, moduleSrc, routeSrc, controllerSrc), {
            transform: function (filepath) {
                return '<script src="~' + filepath + '"></script>';
            },
            ignorePath: '/wwwroot'
        }))
        .pipe(inject(series(styleSrc), {
            transform: function (filepath) {
                return '<link rel="stylesheet" href="~' + filepath + '" />';
            },
            ignorePath: '/wwwroot'
        }))
        .pipe(gulp.dest('./Views/Shared/'));
});