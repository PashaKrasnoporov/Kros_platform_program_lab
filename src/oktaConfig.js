const oktaConfig = {
    clientId: "0oadib4q89zITKz0H5d7",
    issuer: "https://dev-35903550.okta.com/oauth2/default",
    redirectUri: "http://localhost:3000/login/callback",
    scopes: ["openid", "profile", "email"],
    pkce: true,
    disableHttpsChecks: false
}

export default oktaConfig;