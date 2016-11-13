var path = require('path');

module.exports = {
    entry: {
        admin: "./Scripts/admin/app.js",
        common: "./Scripts/common.js",
        home: "./Scripts/home/app.js"
    },
    output: {
        path: path.join(__dirname, 'public'),
        filename: "[name].min.js",
        publicPath: "/public/"
    },
    module: {
        loaders: [
            {
                test: /jquery\.js/,
                loader: 'expose?jQuery'
            }, {
                test: /jquery\.js/,
                loader: 'expose?$'
            },
            {
                test: /\.html$/,
                loader: 'ngtemplate?relativeTo=' + __dirname + '!html'
            },
            {
                test: /\.woff2?$|\.ttf$|\.eot$|\.svg$/,
                loader: "file"
            },
            {
                test: /\.scss$/,
                loaders: ["style", "css", "sass"]
            },
			{ test: /\.css$/, loader: "style!css" },
            {
                test: /\.js$/,
                loader: 'babel',
                query: {
                    presets: ['es2015']
                }
            }
        ]
    }
};