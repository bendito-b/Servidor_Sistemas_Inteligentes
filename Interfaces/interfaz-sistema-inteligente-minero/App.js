import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, Image, Button, TouchableHighlight } from 'react-native';

const sendData = async () => {
  const url = "http://192.168.1.53:5226/api/Hechos/ActividadGeomecanica";

  const data = {
    presionGeologica: 0,
    densidadDelSuelo: 0,
    profundidadDeFisuras: 0,
    indiceDeFracturamiento: 0,
    profundidadDePerforacion: 0,
  };

  const headers = {
    "Content-Type": "application/json",
    "tip_sue": "2",
  };

  try {
    const response = await fetch(url, {
      method: "POST",
      headers: headers,
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const responseData = await response.json();
    alert(JSON.stringify(responseData));
  } catch (error) {
    alert(error.message);
  }
};

export default function App() {
  return (
    <View style={styles.container}>
    <StatusBar style="light" />
      <Text>Esqueleto de la aplicación</Text>
      <Button title="pulsa aquí" onPress={() => sendData()} />
      <Text>\n</Text>
      <TouchableHighlight
        underlayColor={'#09f'}
        style={{
          width: 200,
          height: 200,
          borderRadius: 100,
          backgroundColor: '#fff',
          alignItems: 'center',
          justifyContent: 'center',
        }}
        onPress={() => sendData()}>
          <Text>Pulsa aquí</Text>
      </TouchableHighlight>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#000',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
