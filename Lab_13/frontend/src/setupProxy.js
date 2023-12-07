const { createProxyMiddleware } = require('http-proxy-middleware');
const https = require('https');
const fs = require('fs');

const sslCrtFile = fs.readFileSync('../certkey.pfx');
const sslKeyPassword = 'iushkov';

module.exports = function (app) {
    const httpsServer = https.createServer(
        {
            pfx: sslCrtFile,
            passphrase: sslKeyPassword,
        },
        app
    );

    app.use(
        createProxyMiddleware({
            target: 'https://127.0.0.1:7035',
            changeOrigin: true,
        })
    );

    httpsServer.listen(3000, function () {
        console.log('Development server listening on https://localhost:3000');
    });
};