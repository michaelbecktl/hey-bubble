import { Colors } from '@/constants/Colors'
import { Ionicons } from '@expo/vector-icons'
import { Tabs } from 'expo-router'

export default function TabsLayout() {
  return (
    <Tabs
      screenOptions={{
        headerStyle: {
          backgroundColor: Colors.themeBackground,
        },
        headerTintColor: Colors.secondary,
        tabBarActiveTintColor: Colors.primary,
        tabBarInactiveTintColor: Colors.subHighlight,
        tabBarStyle: {
          backgroundColor: Colors.themeBackground,
        },
        headerBackButtonDisplayMode: 'minimal',
      }}
    >
      <Tabs.Screen
        name="index"
        options={{
          title: 'Home',
          tabBarIcon: ({ color, size, focused }) => (
            <Ionicons
              name={focused ? 'home-sharp' : 'home-outline'}
              color={color}
              size={size}
            />
          ),
        }}
      />

      <Tabs.Screen
        name="about"
        options={{
          title: 'About',
          tabBarIcon: ({ color, size, focused }) => (
            <Ionicons
              name={
                focused
                  ? 'information-circle-sharp'
                  : 'information-circle-outline'
              }
              color={color}
              size={size}
            />
          ),
        }}
      />
      <Tabs.Screen
        name="settings"
        options={{
          title: 'Settings ',
          tabBarIcon: ({ color, size, focused }) => (
            <Ionicons
              name={focused ? 'settings-sharp' : 'settings-outline'}
              color={color}
              size={size}
            />
          ),
        }}
      />
    </Tabs>
  )
}
