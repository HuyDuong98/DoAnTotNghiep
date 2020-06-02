import React, {Component, useState, useEffect} from 'react';

import {
  View,
  Image,
  TouchableOpacity,
  SafeAreaView,
  ScrollView,
  StyleSheet,
  Text,
  AsyncStorage,
  Dimensions,
  ImageBackground,
} from 'react-native';

import {createAppContainer} from 'react-navigation';
import {createDrawerNavigator, DrawerItems} from 'react-navigation-drawer';
import {createStackNavigator} from 'react-navigation-stack';
import GioiThieuScreen from '../../screen/gioiThieu';
import KhuyenMaiScreen from '../../screen/khuyenMai';
import QuyDinhScreen from '../../screen/quyDinh';
import NhungLuuYScreen from '../../screen/luuY';
import ThuTucDatXeScreen from '../../screen/thuTucDatXe';
import HuongDanDatXeScreen from '../../screen/huongDanDatXe';
import CauHoiScreen from '../../screen/cauHoiThuongGap';
import LienHeScreen from '../../screen/lienHe';
import IconEn from 'react-native-vector-icons/Entypo';
import Tab from '../navigationTabs';
import Splash1Screen from '../../screen/splash1';
import Splash2Screen from '../../screen/splash2';
import Splash3Screen from '../../screen/splash3';
import SignInScreen from '../../screen/signIn';
import SignUpScreen from '../../screen/signUp';
const widthScreen = Dimensions.get('screen').width;

const GioiThieu_StackNavigator = createStackNavigator({
  //All the screen from the HomeScreen will be indexed here
  GioiThieu: {
    screen: GioiThieuScreen,
    // navigationOptions: ({navigation, props}) => ({
    //   headerTitleStyle: {fontFamily: 'Vollkorn-Black', fontSize: 20},
    //   title: 'GioiThieu',
    //   headerRight: (
    //     <IconEn
    //       style={{marginLeft: 5}}
    //       name="menu"
    //       size={35}
    //       color="black"
    //       onPress={() => navigation.toggleDrawer()}
    //     />
    //   ),
    //   headerStyle: {
    //     backgroundColor: 'white',
    //   },
    //   headerTintColor: 'black',
    // }),
  },
});

const KhuyenMai_StackNavigator = createStackNavigator({
  //All the screen from the AccountScreen will be indexed here
  KhuyenMai: {
    screen: KhuyenMaiScreen,
    // navigationOptions: ({navigation}) => ({
    //   headerTitleStyle: {fontFamily: 'Vollkorn-Black', fontSize: 20},
    //   title: 'KhuyenMai',
    //   headerLeft: (
    //     <View style={{marginLeft: 5}}>
    //       <TouchableOpacity onPress={() => navigation.toggleDrawer()}>
    //         <IconEn name="menu" size={35} color="black" />
    //       </TouchableOpacity>
    //     </View>
    //   ),
    //   headerStyle: {
    //     backgroundColor: 'white',
    //   },
    //   headerTintColor: 'black',
    // }),
  },
});

const QuyDinh_StackNavigator = createStackNavigator({
  //All the screen from the BlogScreen will be indexed here
  QuyDinh: {
    screen: QuyDinhScreen,
    // navigationOptions: ({navigation}) => ({
    //   headerTitleStyle: {fontFamily: 'Vollkorn-Black', fontSize: 20},
    //   title: 'QuyDinh',
    //   headerLeft: (
    //     <View style={{marginLeft: 5}}>
    //       <TouchableOpacity onPress={() => navigation.toggleDrawer()}>
    //         <IconEn name="menu" size={35} color="black" />
    //       </TouchableOpacity>
    //     </View>
    //   ),
    //   headerStyle: {
    //     backgroundColor: 'white',
    //   },
    //   headerTintColor: 'black',
    // }),
  },
});
const NhungLuuY_StackNavigator = createStackNavigator({
  //All the screen from the BlogScreen will be indexed here
  NhungLuuY: {
    screen: NhungLuuYScreen,
    // navigationOptions: ({navigation}) => ({
    //   headerTitleStyle: {fontFamily: 'Vollkorn-Black', fontSize: 20},
    //   title: 'NhungLuuY',
    //   headerLeft: (
    //     <View style={{marginLeft: 5}}>
    //       <TouchableOpacity onPress={() => navigation.toggleDrawer()}>
    //         <IconEn name="menu" size={35} color="black" />
    //       </TouchableOpacity>
    //     </View>
    //   ),
    //   headerStyle: {
    //     backgroundColor: 'white',
    //   },
    //   headerTintColor: 'black',
    // }),
  },
});

///1
const ThuTucDatXe_StackNavigator = createStackNavigator({
  //All the screen from the BlogScreen will be indexed here
  ThuTucDatXe: {
    screen: ThuTucDatXeScreen,
    // navigationOptions: ({navigation}) => ({
    //   headerTitleStyle: {fontFamily: 'Vollkorn-Black', fontSize: 20},
    //   title: 'ThuTucDatXe',
    //   headerLeft: (
    //     <View style={{marginLeft: 5}}>
    //       <TouchableOpacity onPress={() => navigation.toggleDrawer()}>
    //         <IconEn name="menu" size={35} color="black" />
    //       </TouchableOpacity>
    //     </View>
    //   ),
    //   headerStyle: {
    //     backgroundColor: 'white',
    //   },
    //   headerTintColor: 'black',
    // }),
  },
});
// 2
const HuongDanDatXe_StackNavigator = createStackNavigator({
  //All the screen from the BlogScreen will be indexed here
  HuongDanDatXe: {
    screen: HuongDanDatXeScreen,
    // navigationOptions: ({navigation}) => ({
    //   headerTitleStyle: {fontFamily: 'Vollkorn-Black', fontSize: 20},
    //   title: 'HuongDanDatXe',
    //   headerLeft: (
    //     <View style={{marginLeft: 5}}>
    //       <TouchableOpacity onPress={() => navigation.toggleDrawer()}>
    //         <IconEn name="menu" size={35} color="black" />
    //       </TouchableOpacity>
    //     </View>
    //   ),
    //   headerStyle: {
    //     backgroundColor: 'white',
    //   },
    //   headerTintColor: 'black',
    // }),
  },
});
//3
const CauHoi_StackNavigator = createStackNavigator({
  //All the screen from the BlogScreen will be indexed here
  CauHoi: {
    screen: CauHoiScreen,
    // navigationOptions: ({navigation}) => ({
    //   headerTitleStyle: {fontFamily: 'Vollkorn-Black', fontSize: 20},
    //   title: 'CauHoiThuongGap',
    //   headerLeft: (
    //     <View style={{marginLeft: 5}}>
    //       <TouchableOpacity onPress={() => navigation.toggleDrawer()}>
    //         <IconEn name="menu" size={35} color="black" />
    //       </TouchableOpacity>
    //     </View>
    //   ),
    //   headerStyle: {
    //     backgroundColor: 'white',
    //   },
    //   headerTintColor: 'black',
    // }),
  },
});
//4
const LienHe_StackNavigator = createStackNavigator({
  //All the screen from the BlogScreen will be indexed here
  LienHe: {
    screen: LienHeScreen,
    // navigationOptions: ({navigation}) => ({
    //   headerTitleStyle: {fontFamily: 'Vollkorn-Black', fontSize: 20},
    //   title: 'LienHe',
    //   headerLeft: (
    //     <View style={{marginLeft: 5}}>
    //       <TouchableOpacity onPress={() => navigation.toggleDrawer()}>
    //         <IconEn name="menu" size={35} color="black" />
    //       </TouchableOpacity>
    //     </View>
    //   ),
    //   headerStyle: {
    //     backgroundColor: 'white',
    //   },
    //   headerTintColor: 'black',
    // }),
  },
});

const CustomDrawerComponent = props => {
  return (
    <ImageBackground
      source={require('../../../assets/image/backgroundMenu.png')}
      style={{flex: 1, width: widthScreen}}>
      <View style={{flex: 1}}>
        <TouchableOpacity
          style={{margin: 10}}
          onPress={() => {
            props.navigation.closeDrawer();
          }}>
          <Image
            source={require('../../../assets/image/closeDrawer.png')}
            // size={40}
          />
        </TouchableOpacity>

        <View
          style={{
            alignItems: 'center',
          }}>
          <View
            style={{
              justifyContent: 'center',
              alignItems: 'center',
              width: 80,
              height: 80,
              padding: 5,
              borderColor: 'gray',
              borderWidth: 1,
              borderRadius: 50,
              backgroundColor: 'gray',
              marginTop: 5,
            }}>
            <Image source={require('../../../assets/image/user.png')} />
          </View>
          <View style={{marginTop: 19}}>
            <Text
              style={{
                marginRight: 10,
                fontSize: 15,
                fontFamily: 'Montserrat-Bold',
              }}>
              Đoàn Văn Minh Anh
            </Text>
          </View>
          <Text style={{fontFamily: 'Montserrat', marginTop: 9, fontSize: 13}}>
            284 Man Thiện, P.Tăng Nhơn Phú A, Q.9
          </Text>
        </View>

        <ScrollView style={{marginTop: 43, marginHorizontal: 30}}>
          <DrawerItems
            {...props}
            itemStyle={{
              borderBottomWidth: 1,
              borderColor: 'black',
              marginRight: 30,
              fontFamily: 'Montserrat-SemiBold',
              fontSize: 15,
            }}
          />
        </ScrollView>
      </View>
    </ImageBackground>
  );
};

const DrawerNavigator = createDrawerNavigator(
  {
    HomeTab: {
      screen: Tab,
      navigationOptions: {
        drawerLabel: 'Danh Mục',
      },
    },
    //Drawer Optons and indexing
    GioiThieu: {
      //Title
      screen: GioiThieu_StackNavigator,

      navigationOptions: {
        drawerLabel: 'Giới Thiệu',

        // drawerIcon: ({tintColor}) => (
        //   <IconAn name="home" color={tintColor} size={27} />
        // ),
      },
    },
    KhuyenMai: {
      //Title
      screen: KhuyenMai_StackNavigator,
      navigationOptions: {
        drawerLabel: 'Khuyến mãi sốc',
        // drawerIcon: ({tintColor}) => (
        //   <IconAn name="antdesign" color={tintColor} size={27} />
        // ),
      },
    },

    QuyDinh: {
      //Title
      screen: QuyDinh_StackNavigator,
      navigationOptions: {
        drawerLabel: 'Quy định chung',
        // drawerIcon: ({tintColor}) => (
        //   <IconFontA5 name="blog" color={tintColor} size={27} />
        // ),
      },
    },

    NhungLuuY: {
      //Title
      screen: NhungLuuY_StackNavigator,
      navigationOptions: {
        drawerLabel: 'Những lưu ý khi thuê xe',
        // drawerIcon: ({tintColor}) => (
        //   <IconEn name="user" size={27} color={tintColor} />
        // ),
      },
    },
    //1
    ThuTucDatXe: {
      //Title
      screen: ThuTucDatXe_StackNavigator,
      navigationOptions: {
        drawerLabel: 'Thủ tục đặt xe',
        // drawerIcon: ({tintColor}) => (
        //   <IconEn name="user" size={27} color={tintColor} />
        // ),
      },
    },
    //2
    HuongDanDatXe: {
      //Title
      screen: HuongDanDatXe_StackNavigator,
      navigationOptions: {
        drawerLabel: 'Hướng dẫn đặt xe',
        // drawerIcon: ({tintColor}) => (
        //   <IconEn name="user" size={27} color={tintColor} />
        // ),
      },
    },
    //3
    CauHoi: {
      //Title
      screen: CauHoi_StackNavigator,
      navigationOptions: {
        drawerLabel: 'Câu hỏi thường gặp',
        // drawerIcon: ({tintColor}) => (
        //   <IconEn name="user" size={27} color={tintColor} />
        // ),
      },
    },
    //4
    LienHe: {
      //Title
      screen: LienHe_StackNavigator,
      navigationOptions: {
        drawerLabel: 'Liên hệ',
        // drawerIcon: ({tintColor}) => (
        //   <IconEn name="user" size={27} color={tintColor} />
        // ),
      },
    },
  },
  {
    initialRouteName:'HomeTab',
    contentComponent: CustomDrawerComponent,
    contentOptions: {
      activeTintColor: '#fff',
      inactiveTintColor: 'black',
      activeBackgroundColor: '#FFD50D',
    },
    drawerPosition: 'right',
    drawerType: 'front',
    drawerWidth: widthScreen - 29,
  },
);
const Main_StackNavigator = createStackNavigator({
  //All the screen from the AccountScreen will be indexed here
  drawer: {
    screen: DrawerNavigator,
    navigationOptions: {header: null}
  },
  splash1: {
    screen: Splash1Screen,
    navigationOptions: {header: null}
  },
  splash2: {
    screen: Splash2Screen,
    navigationOptions: {header: null}
  },
  splash3: {
    screen: Splash3Screen,
    navigationOptions: {header: null}
  },
  signup: {
    screen: SignUpScreen,
    navigationOptions: {header: null}
  },
  signin: {
    screen: SignInScreen,
    navigationOptions: {header: null}
  },
}
,
{
  initialRouteName: 'splash1',
  
},
);

const AppDrawerNavigator = createAppContainer(Main_StackNavigator);

export default class App extends React.Component {
  static navigationOptions = {
    title: 'Home',
    headerStyle: {},
  };
  render() {
    return <AppDrawerNavigator />;
  }
}
