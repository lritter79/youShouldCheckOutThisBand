/// <binding AfterBuild='default' />
//gulp is the core framewokr that allows you to set up tasks
let gulp = require('gulp');
let uglify = require('gulp-uglify');
let concat = require('gulp-concat');


gulp.task("minify", function () {
    //src allows you to specify which files you deal with
    // take the source of some files -> send an do some thing wiht them -> end te back out
    //this finds js files in the js direcotry with the tha name (any).js
    return gulp.src('wwwroot/js/*.js')
        //uglify takes all files and minifies them seperately until we pipe concat
        .pipe(uglify())
        //yscotb.min.js is the name of the output file
        .pipe(concat("yscotb.min.js"))
        .pipe(gulp.dest("wwwroot/dist"));

});

//this is what rusn when gulp is called on its own
//[] groups tasks
gulp.task('default', gulp.series("minify"));