import { createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import HomePage from "../../features/home/HomePage";
import UsersPage from "../../features/users/UsersPage";
import UserDetails from "../../features/users/UserDetails";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "", element: <HomePage /> },
            { path: "users", element: <UsersPage />},
            { path: "users/:id", element: <UserDetails />}
        ],
    },
]);
