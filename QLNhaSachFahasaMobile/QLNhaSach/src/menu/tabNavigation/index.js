import React from 'react';
import {Image} from 'react-native';
import {createAppContainer} from 'react-navigation';
import {createBottomTabNavigator} from 'react-navigation-tabs';
import {createStackNavigator} from 'react-navigation-stack';
import TabBar from '../../components/tabBar';
import HomeScreen from '../../screen/home';
import CategoryScreen from '../../screen/category';
import SearchScreen from '../../screen/search';
import CartScreen from '../../screen/cart';
import ProfileScreen from '../../screen/profile';

/* declaration of stacks */
const HomeStack = createStackNavigator({
  home: {screen: HomeScreen, navigationOptions: {header: null}},
});
const CategoryStack = createStackNavigator({
  category: {screen: CategoryScreen, navigationOptions: {header: null}},
});
const SearchStack = createStackNavigator({
  search: {screen: SearchScreen, navigationOptions: {header: null}},
});
const CartStack = createStackNavigator({
  cart: {screen: CartScreen, navigationOptions: {header: null}},
});
const ProfileStack = createStackNavigator({
  profile: {screen: ProfileScreen, navigationOptions: {header: null}},
});

const BottomNavigatior = createBottomTabNavigator(
  {
    Home: {
      screen: HomeStack,
      navigationOptions: ({navigation}) => ({
        headerTitleStyle: {
          width: 56,
          height: 14,
          fontFamily: 'Montserrat',
          fontSize: 11,
        },
        title: 'Trang chủ',
      }),
    },
    Category: {
      screen: CategoryStack,
      navigationOptions: ({navigation}) => ({
        headerTitleStyle: {
          width: 56,
          height: 14,
          fontFamily: 'Montserrat',
          fontSize: 11,
        },
        title: 'Danh mục',
      }),
    },
    Search: {
      screen: SearchStack,
      navigationOptions: ({navigation}) => {},
    },
    Cart: {
      screen: CartStack,
      navigationOptions: ({navigation}) => ({
        headerTitleStyle: {
          width: 56,
          height: 14,
          fontFamily: 'Montserrat',
          fontSize: 11,
        },
        title: 'Giỏ hàng',
      }),
    },
    Profile: {
      screen: ProfileStack,
      navigationOptions: ({navigation}) => ({
        headerTitleStyle: {
          width: 56,
          height: 14,
          fontFamily: 'Montserrat',
          fontSize: 11,
        },
        title: 'Tài khoản',
      }),
    },
  },
  {
    defaultNavigationOptions: ({navigation}) => ({
      tabBarIcon: ({focused, horizontal, tintColor}) => {
        const {routeName} = navigation.state;
        let iconName;
        if (routeName === 'Home') {
          iconName = 'https://cdn.onlinewebfonts.com/svg/img_402676.png';
        } else if (routeName === 'Category') {
          iconName =
            'https://i.ya-webdesign.com/images/category-icons-png-4.png';
        } else if (routeName === 'Search') {
          iconName = 'https://img.icons8.com/pastel-glyph/2x/search--v2.png';
        } else if (routeName === 'Cart') {
          iconName = 'https://cdn.onlinewebfonts.com/svg/img_290616.png';
        } else if (routeName === 'Profile') {
          iconName =
            'https://superawesomevectors.com/wp-content/uploads/2017/10/person-outline-free-vector-icon-800x566.jpg';
        }

        return (
          <Image
            source={{uri: iconName}}
            style={{
              width: routeName === 'Search' ? 38.4 : 24.3,
              height: routeName === 'Search' ? 40 : 24.4,
              tintColor: tintColor,
            }}
          />
        );
      },
    }),
    tabBarComponent: props => <TabBar {...props} />,
    tabBarOptions: {
      tabFeatured: 'Search',
      backgroundFeaturedIcon: '#FF0000',
      activeFeaturedTintColor: 'black',
      inactiveFeatureTintColor: 'black',

      showLabel: true,
      activeTintColor: '#FF0000',
      inactiveTintColor: 'black',
      style: {
        height: 55,
        backgroundColor: '#fff',
        borderTopWidth: 1,
        borderTopColor: '#fff',
      },
      tabStyle: {},
    },
  },
);

export default createAppContainer(BottomNavigatior);
