import { Navigate, Outlet, useLocation } from "react-router-dom";
import { useAppSelector } from "../store/configureStore"
import { toast } from "react-toastify";

interface Props {
    roles?: string[];
}

export default function RequireAuth({roles}: Props) {
    const {user} = useAppSelector(state => state.user);
    const location = useLocation();

    if (!user) {
        return <Navigate to="/login" state={{from: location}} />
    }

    if (roles && !roles.some(r => user.roles?.includes(r))) {
        toast.error('Você não tem permissão para acessar essa página!');
        return <Navigate to="/" />
    }

    return <Outlet />
}