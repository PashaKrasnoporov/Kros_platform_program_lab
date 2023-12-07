import { React, useState, useEffect } from 'react';
import { useOktaAuth } from '@okta/okta-react';
import { Link } from "react-router-dom"

const useAuthUser = () => {
    const { oktaAuth, authState } = useOktaAuth();
    const [userInfo, setUserInfo] = useState(null);

    useEffect(() => {
        const getUser = async () => {
            try {
                const res = await oktaAuth.getUser();
				console.log(res)
                setUserInfo(res);
            } catch (error) {
                console.log(error);
            }
        };
        authState?.isAuthenticated && getUser();
    }, [authState, oktaAuth]);

    return userInfo;
};

function Profile() {
    const userInfo = useAuthUser();
    const { oktaAuth, authState } = useOktaAuth();

    const signOut = async () => {
        oktaAuth.signOut();
    };

    return(
        <body>
            <p><b>Nickname</b>: {userInfo?.nickname}</p>
            <p><b>First name</b>: {userInfo?.given_name}</p>
            <p><b>Last name</b>: {userInfo?.family_name}</p>
            <p><b>Patronymic</b>: {userInfo?.middle_name}</p>
            <p><b>Email</b>: {userInfo?.email}</p>
            <p><b>Phone number</b>: {userInfo?.phone_number}</p>

            <Link to="/lab1"><button>Lab1</button></Link>
            <Link to="/lab2"><button>Lab2</button></Link>
            <Link to="/lab3"><button>Lab3</button></Link>
            <button onClick={signOut}>Sign out</button>
        </body>
    );
}

export default Profile;