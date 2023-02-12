import React, { useState, useEffect } from 'react';
import { View, FlatList, Text, Image, TouchableOpacity, StatusBar } from 'react-native';
import styles from '..//../styles//Style';
import { useIsFocused } from '@react-navigation/native';

export default function Feed() {
    const [posts, setPosts] = useState([]);
    const isFocused = useIsFocused();
    
    async function loadPosts() {
        fetch('http://192.168.0.2:5066/api/Sweets')
        .then(response => response.json())
        .then(data => {
            setPosts(data);
            console.error("deu bom o request");
        })
        .catch(error => {
            console.error("deu ruim o request");
        }
        );


    }
    
    useEffect(() => {
        loadPosts();
    }, [isFocused]);
    
    return (
        <View style={styles.container}>
        <StatusBar barStyle="dark-content" backgroundColor="#f0f0f5" />
        
        
        <FlatList
            data={posts}
            style={styles.postList}
            keyExtractor={post => String(post.id)}
            showsVerticalScrollIndicator={false}
            renderItem={({ item: post }) => (
            <View style={styles.post}>
                <Text style={styles.postProperty}>Autor:</Text>
                <Text style={styles.postValue}>{post.userName}</Text>
    
                <Text style={styles.postProperty}>Post:</Text>
                <Text style={styles.postValue}>{post.text}</Text>
    
                
            </View>
            )}
        />
        </View>
    );
}

