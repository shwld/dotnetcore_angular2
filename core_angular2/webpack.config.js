var webpack = require('webpack');
var path = require('path');
var ExtractTextPlugin = require("extract-text-webpack-plugin");

// Webpack Config
var webpackConfig = {
    entry: {
        'app': './Client/app/app.ts',
        'vendor': './Client/vendor.ts',
        'app-style': './Client/app-style.ts',
        'vendor-style': './Client/vendor-style.ts',
    },

    devtool: 'source-map',

    cache: true,
    output: {
        path: './wwwroot/dist',
        filename: '[name].bundle.js',
        sourceMapFilename: '[name].map',
        chunkFilename: '[id].chunk.js'
    },

    resolve: {
        extensions: ['', '.ts', '.js']
    },

    plugins: [
      new webpack.ProvidePlugin({
          $: "jquery",
          jQuery: "jquery",
          "window.jQuery": "jquery"
      }),
      new webpack.ProvidePlugin({ "window.Tether": "tether" }),
      new webpack.optimize.CommonsChunkPlugin({ name: ['app', 'vendor', 'polyfills'], minChunks: Infinity }),
      new ExtractTextPlugin("[name].css"),
      new webpack.optimize.DedupePlugin()
    ],

    module: {
        loaders: [
          // .ts files for TypeScript
            { test: /\.ts$/, loader: 'ts-loader' },
            { test: /\.css$/, loader: ExtractTextPlugin.extract("style-loader", "css-loader") },
            { test: /\.scss$/, loader: ExtractTextPlugin.extract("style-loader", "css-loader!sass-loader") },
            { test: /\.sass$/, loader: ExtractTextPlugin.extract("style-loader", "css-loader!sass-loader") },
            { test: /\.less$/, loader: ExtractTextPlugin.extract("style-loader", "css-loader!less-loader") },
            { test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "url-loader?limit=10000&mimetype=application/font-woff" },
            { test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "file-loader" }
        ]
    }

};

var webpackMerge = require('webpack-merge');
module.exports = webpackMerge(webpackConfig);