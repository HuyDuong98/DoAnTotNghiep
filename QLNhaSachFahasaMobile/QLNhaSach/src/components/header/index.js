import React, { Component } from "react";

import {
  Text,
  View,
  Image,
  TouchableHighlight,
  Alert,
  TouchableOpacity,
  TextInput,
} from "react-native";
import IconEn from "react-native-vector-icons/Entypo";
import { RFPercentage, RFValue } from "react-native-responsive-fontsize";

export default class HeaderComponent extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <View
        style={{
          height: "10%",
          width: "100%",
          position: this.props.changeHeader == true ? "absolute" : "relative",
        }}
      >
        <View
          style={{
            height: "100%",
            width: "100%",
            position: "absolute",
            backgroundColor: "black",
            opacity: this.props.hiddenImageHeader == true ? 0 : 1,
          }}
        >
          <Image
            style={{
              width: "100%",
              height: "100%",
              opacity: 0.4,
              position: "absolute",
            }}
            source={require("../../../assets/image/imageHeader.png")}
          />
        </View>
        <View
          style={{
            flexDirection: "row",
            position: "absolute",
            height: "60%",
            width: "100%",
            alignItems: "center",
            justifyContent: "center",
            opacity: this.props.hiddenImageHeader == true ? 0 : 1,
          }}
        >
          <Image
            resizeMode="stretch"
            style={{ height: "50%", width: "80%" }}
            source={require("../../../assets/image/logo.png")}
          />
        </View>
        <View
          style={{
            flexDirection: "row",
            justifyContent: "flex-end",
            height: "60%",
          
          }}
        >
          <TouchableOpacity
            style={{ height: "100%",width:"6%" ,marginRight:"2%",justifyContent:'center'}}
          >
            <Image
              resizeMode="stretch"
              source={require("../../../assets/image/notification.png")}
              style={{ tintColor: "white", height: "35%",width:"100%" }}
            />
          </TouchableOpacity>
          <TouchableOpacity
            style={{ height: "100%", width:"6%",marginRight:"2%",justifyContent:'center' }}
            onPress={() => this.props.open()}
          >
            <Image
              resizeMode="stretch"
              source={require("../../../assets/image/menu.png")}
              style={{ tintColor: "white", height: "35%",width:"100%" }}
            />
          </TouchableOpacity>
        </View>
        <View
          style={{
            opacity: this.props.hiddenSearchBar == true ? 0 : 1,
            height: "40%",
            width: "100%",
            backgroundColor: "#FFD50D",
            padding: 5,
          }}
        >
          <View
            style={{
              borderTopLeftRadius: 200,
              borderTopRightRadius: 200,
              borderBottomLeftRadius: 200,
              borderBottomRightRadius: 200,
              backgroundColor: "#fff",
              height: "100%",
              width: "100%",
              flexDirection: "row",
              justifyContent: "flex-end",
              alignItems: "center",
            }}
          >
            <TextInput
              style={{ flex: 8, marginLeft: 5, height: 40 ,fontSize:RFValue(11, 580)}}
            
              placeholder="Bạn muốn đi xe gì hôm nay?"
            />
            <Image
              style={{ marginRight: 10 }}
              source={require("../../../assets/image/search.png")}
            />
          </View>
        </View>
      </View>
    );
  }
}
