import React, { useState, useEffect } from 'react';

export default function Posts() {
    const [posts, setPosts] = useState([]);
   
    const updatePost = ()=>{
        fetch("http://localhost:5066/api/Sweets")
            .then(e => e.json())
            .then(data => {
                setPosts(data);
            });
    }
    
    useEffect(() => {
        updatePost();

    }, []);

    return (
        <div className='posts' style={{display:'flex',justifyContent:"center",alignItems:"center",flexDirection:"column",border:"solid 1px red"}}>
                       
            {posts.map(post => (
                <div key={post.id} className='post' style={{border:"solid 1px red", width:"400px"}}>
                    <div>@{post.userName}</div>
                    <div>{post.text}</div>
                    <div>{post.dataPostagem}</div>
                </div>))
            }
            

        </div>


    )
        ;
};