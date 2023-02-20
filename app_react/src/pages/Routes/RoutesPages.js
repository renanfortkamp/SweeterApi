
import { BrowserRouter,Routes, Route } from 'react-router-dom';
import React from 'react';
import Feed from '../feed/feed.js';
import Login from '../login/login.js';
import Register from '../register/register.js';

export default function RoutesPages() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" exact element={<Feed />} />
                <Route path="/feed" element={<Feed />} />
                <Route path="/register" element={<Login />} />
                <Route path="/login" element={<Register />} />
            </Routes>
        </BrowserRouter>
    );
}