import axios from "axios";
import React,{ Component } from "react";
import CategoryList from "./CategoryList";

import Navigation from "./Navigation";

export default class App extends Component {
    state={
        categories: [],
        search:"",
    };

catList=()=>{
    axios.get(`https://localhost:7106/api/categories`);
    const newCatList=this.state.categories;
    this.setState((state)=>({
        categories:newCatList,
    }));
    console.log(this.state.categories);
};
    render(){
        return (
            <div>
                <div className="header">
                    <Navigation/>
                </div>
                <div className="container">
                    <CategoryList catListProp={this.catList}/>
                </div>
            </div>
       ) ;
    
    }
}