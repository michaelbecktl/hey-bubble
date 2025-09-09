import { Modal, View, Text, StyleSheet } from 'react-native'
import FontAwesome6 from '@expo/vector-icons/FontAwesome6'
import BadgeButton from '@/components//BadgeButton'

type Props = {
  modalVisible: boolean
  setModalVisible: (modalVisible: boolean) => void
  proceedToLogin: () => void
}

function RegisterSuccessfully({
  modalVisible,
  setModalVisible,
  proceedToLogin,
}: Props) {
  // Function should close both registration and confirmation pop-up and redirect user to login modal

  return (
    <Modal
      animationType="slide"
      transparent={true}
      visible={modalVisible}
      onRequestClose={() => setModalVisible(!modalVisible)}
    >
      <View style={styles.container}>
        <View>
          <View style={styles.modalView}>
            <View style={styles.icon}>
              <FontAwesome6 name="user-check" size={36} color="#9A348E" />
            </View>
            <Text>Registration Successful!</Text>
            <Text>Please proceed to login screen</Text>
          </View>
          <BadgeButton onPress={proceedToLogin} type="x" position="topRight" />
        </View>
      </View>
    </Modal>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    marginTop: 22,
  },
  modalView: {
    margin: 20,
    backgroundColor: 'white',
    borderRadius: 20,
    padding: 70,
    alignItems: 'center',
    boxShadow: '0px 2px 4px rgba(0, 0, 0, 0.25)',
    elevation: 5,
  },
  icon: {
    margin: 10,
  },
})

export default RegisterSuccessfully
