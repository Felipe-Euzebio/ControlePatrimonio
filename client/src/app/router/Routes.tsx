import { createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import HomePage from "../../features/home/HomePage";
import UsersPage from "../../features/users/UsersPage";
import UserDetails from "../../features/users/UserDetails";
import RequireAuth from "./RequireAuth";
import Login from "../../features/users/Login";
import Register from "../../features/users/Register";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            // Authenticated routes
            { 
                element: <RequireAuth />, 
                children: [
                    { path: "users", element: <UsersPage />},
                    { path: "users/:id", element: <UserDetails />},
                ] 
            },
            // Public routes
            { path: "", element: <HomePage /> },
            { path: "login", element: <Login /> },
            { path: "register", element: <Register /> },
        ],
    },
]);
