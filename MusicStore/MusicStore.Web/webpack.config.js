var path = require('path');
var ExtractTextPlugin = require("extract-text-webpack-plugin");

module.exports = {
    entry: {
        admin: "./Scripts/admin/app.js",
        common: "./Scripts/common.js",
        home: "./Scripts/home/app.js"
    },
    output: {
        path: path.join(__dirname, 'public'),
        filename: "[name].min.js",
        publicPath: ""
    },
    devtool: "source-map",
    plugins: [
        new ExtractTextPlugin("[name].min.css")
    ],
    module: {
        loaders: [
            {
                test: /jquery\.js/,
                loader: 'expose-loader?jQuery'
            }, {
                test: /jquery\.js/,
                loader: 'expose-loader?$'
            },
            {
                test: /\.html$/,
                loader: 'ngtemplate-loader?relativeTo=' + __dirname + '!html'
            },
            {
                test: /\.css$/,
                loader: ExtractTextPlugin.extract('style-loader', 'css-loader!resolve-url-loader')
            }, {
                test: /\.scss$/,
                loader: ExtractTextPlugin.extract('style-loader', 'css-loader!resolve-url-loader!sass-loader')
            },
            {
                test: /\.(eot|svg|ttf|woff|woff2)$/,
                loader: 'file-loader?name=[name].[ext]'
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                query: {
                    presets: ['es2015']
                }
            }
        ]
    }
};