import {
    Home,
    Lab1,
    Lab2,
    Lab3
} from "./components";

const AppRoutes = [
    {
        index: true,
        path: '/',
        element: <Home/>,
        secure: false
    },
    {
        path: '/lab1',
        element: <Lab1/>,
        secure: true
    },
    {
        path: '/lab2',
        element: <Lab2/>,
        secure: true
    },
    {
        path: '/lab3',
        element: <Lab3/>,
        secure: true
    }
];

export default AppRoutes;
