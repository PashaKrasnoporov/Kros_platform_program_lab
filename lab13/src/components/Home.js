import React from 'react';
import { useOktaAuth } from '@okta/okta-react';
import { Link } from 'react-router-dom';

function Home() {
    const { authState, oktaAuth } = useOktaAuth();

    if (!oktaAuth) {
        return(<p>Loading...</p>)
    } else {
        const signIn = async () => {
            oktaAuth.signInWithRedirect ({originalUri: "profile"});
        };
    
        return(
            <body>
                <h1>Лабораторна робота №13</h1>
            
                <p>Створення веб-застосунку React (FE) + C# (BE) з авторизацією та аутентифікацією для виконання програмного коду лабораторних 1-3</p>
                { 
                    !authState || !authState.isAuthenticated ? (
                        <button onClick={signIn}>Sign in</button>
                    ) : (
                        <Link to="/profile">
                            <button>Profile</button>
                        </Link>
                    )
                }
            </body>
          );
    }
}

export default Home;