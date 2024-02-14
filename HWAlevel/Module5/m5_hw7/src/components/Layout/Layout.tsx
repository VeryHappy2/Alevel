import  { FC, ReactNode } from "react";
import { Header } from "../header/header";
import React from "react";


interface LayoutProps {
    children: ReactNode;
}

export const Layout: FC<LayoutProps> =({children}) => {
    return (
        <>
            <Header/>
            {children}
        </>      
    );
}