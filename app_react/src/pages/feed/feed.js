import React, { useState,useEffect,useContext } from 'react';
import Posts from './Posts.js';
import Context from '../Context/Context.js';

export default function Feed() {
    const [text, setText] = useState('');
    const [posts, setPosts] = useState("");
    const [context] = useContext(Context);

    const updatePost = () => {
        setPosts("Atualizando...");
        setTimeout(() => {
            setPosts(<Posts />);
        }, 300);
    };

    useEffect(() => {
        updatePost();
    }, []);

    console.log(context.name);

    const postMessage = (e) => {
        try {
            e.preventDefault();
            fetch("http://localhost:5066/api/Sweets?userId="+context.id, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    text: text,
                })

                
            })
                .then(updatePost())
                

        } catch (error) {
            alert(error);
        }
    };

    return (
        <div className='posts' style={{display:'flex',justifyContent:"center",alignItems:"center",flexDirection:"column",border:"solid 1px red"}}>
            <h1>Feed</h1>
            {<p>Bem vindo {context.name}</p>}
            <form onSubmit={(e)=>{postMessage(e)}}>
                <input type="text" placeholder="text" onChange={(e) => setText(e.target.value)} />
                <button type="submit">Submit</button>
            </form>

            {posts}
            
            

        </div>


    )
        ;
};