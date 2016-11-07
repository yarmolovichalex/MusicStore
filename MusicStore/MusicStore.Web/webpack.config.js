var path = require('path');
module.exports = {
    entry: "./Scripts/app.js",
    output: {
        filename: "./public/bundle.js"
    },
    module: {
        loaders: [
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