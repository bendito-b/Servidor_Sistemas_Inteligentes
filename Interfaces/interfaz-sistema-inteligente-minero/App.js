import React, { useState } from "react";
import {
  StyleSheet,
  Text,
  View,
  TextInput,
  Button,
  Pressable,
  ScrollView,
} from "react-native";

export default function App() {
  const [selectedSoil, setSelectedSoil] = useState(null);
  const [headerValue, setHeaderValue] = useState(1);
  const [inputValues, setInputValues] = useState({});

  const soils = [
    {
      name: "Sedimentarios",
      inputs: [
        "Presión Geológica",
        "Densidad del Suelo",
        "Profundidad de Fisuras",
        "Índice de Fracturamiento",
        "Profundidad de Perforación",
      ],
      api: "/api/Hechos/ActividadGeomecanica",
    },
    {
      name: "Vertisoles",
      inputs: [
        "Presión Geológica",
        "Densidad del Suelo",
        "Profundidad de Fisuras",
        "Índice de Fracturamiento",
        "Profundidad de Perforación",
      ],
      api: "/api/Hechos/ActividadGeomecanica",
    },
    {
      name: "Residuales",
      inputs: [
        "Elementos Traza",
        "Concentración Óxidos Metálicos",
        "pH",
        "Conductividad Iónica",
        "Grado Meteorización",
      ],
      api: "/api/Hechos/ComposicionGeoquimica",
    },
    {
      name: "Oxisoles",
      inputs: [
        "Elementos Traza",
        "Concentración Óxidos Metálicos",
        "pH",
        "Conductividad Iónica",
        "Grado Meteorización",
      ],
      api: "/api/Hechos/ComposicionGeoquimica",
    },
    {
      name: "Lateritas",
      inputs: [
        "Resistividad Eléctrica",
        "Magnetismo",
        "Saturación de Agua",
        "Susceptibilidad Magnética",
        "Contenido Óxidos Metálicos",
      ],
      api: "/api/Hechos/ConductividadMagnetismo",
    },
    {
      name: "Glaciales",
      inputs: [
        "Resistividad Eléctrica",
        "Magnetismo",
        "Saturación de Agua",
        "Susceptibilidad Magnética",
        "Contenido Óxidos Metálicos",
      ],
      api: "/api/Hechos/ConductividadMagnetismo",
    },
    {
      name: "Andosoles",
      inputs: [
        "pH",
        "Temperatura",
        "Porosidad",
        "Agua Subterránea",
        "Alteración Hidrotermal",
      ],
      api: "/api/Hechos/PotencialHidrotermal",
    },
    {
      name: "Entisoles",
      inputs: [
        "pH",
        "Temperatura",
        "Porosidad",
        "Agua Subterránea",
        "Alteración Hidrotermal",
      ],
      api: "/api/Hechos/PotencialHidrotermal",
    },
  ];

  const reset = () => {
    setSelectedSoil(null);
    setHeaderValue(1);
    setInputValues({});
  };

  const handleInputChange = (field, value) => {
    const sanitizedField = field.replace(/\s+/g, ""); // Remove spaces from field names
    setInputValues((prevValues) => ({
      ...prevValues,
      [sanitizedField]: value,
    }));
  };

  const sendData = async () => {
    if (!selectedSoil) return;

    const url = `http://192.168.1.53:5226${selectedSoil.api}`;
    const headers = {
      "Content-Type": "application/json",
      tip_sue: headerValue === 1 ? "1" : "2",
    };

    try {
      const response = await fetch(url, {
        method: "POST",
        headers: headers,
        body: JSON.stringify(inputValues),
      });

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      const responseData = await response.json();
      alert(`Respuesta recibida: ${JSON.stringify(responseData)}`);
    } catch (error) {
      alert(`Error: ${error.message}`);
    }
  };

  const renderInputs = (inputs) => (
    <View>
      {inputs.map((label, index) => (
        <View key={index} style={styles.inputGroup}>
          <Text style={styles.label}>{label}</Text>
          <TextInput
            style={styles.input}
            keyboardType="numeric"
            placeholder="Ingrese valor"
            value={inputValues[label.replace(/\s+/g, "")] || ""} // Match sanitized field names
            onChangeText={(value) => handleInputChange(label, value)}
          />
        </View>
      ))}
      <Pressable style={styles.predictButton} onPress={sendData}>
        <Text style={styles.predictButtonText}>Predecir</Text>
      </Pressable>
    </View>
  );

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <Text style={styles.header}>Header: {headerValue}</Text>
      {!selectedSoil ? (
        <View style={styles.buttonContainer}>
          {soils.map((soil, index) => (
            <Pressable
              key={index}
              style={styles.soilButton}
              onPress={() => {
                setSelectedSoil(soil);
                setHeaderValue(index % 2 === 0 ? 1 : 2); // Alternate headers by soil index
              }}
            >
              <Text style={styles.soilButtonText}>{soil.name}</Text>
            </Pressable>
          ))}
        </View>
      ) : (
        <View style={styles.inputContainer}>
          <Pressable style={styles.backButton} onPress={reset}>
            <Text style={styles.backButtonText}>Regresar</Text>
          </Pressable>
          {renderInputs(selectedSoil.inputs)}
        </View>
      )}
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: {
    flexGrow: 1,
    padding: 20,
    backgroundColor: "#f0f0f0",
    alignItems: "center",
  },
  header: {
    fontSize: 24,
    fontWeight: "bold",
    marginBottom: 20,
  },
  buttonContainer: {
    flexDirection: "row",
    flexWrap: "wrap",
    justifyContent: "space-between",
  },
  soilButton: {
    backgroundColor: "#4CAF50",
    padding: 10,
    margin: 10,
    width: "45%",
    alignItems: "center",
    borderRadius: 5,
  },
  soilButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
  inputContainer: {
    width: "100%",
  },
  backButton: {
    backgroundColor: "#f44336",
    padding: 10,
    marginBottom: 20,
    alignItems: "center",
    borderRadius: 5,
  },
  backButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
  inputGroup: {
    marginBottom: 15,
  },
  label: {
    fontSize: 14,
    marginBottom: 5,
  },
  input: {
    borderWidth: 1,
    borderColor: "#ccc",
    borderRadius: 5,
    padding: 8,
    fontSize: 14,
  },
  predictButton: {
    backgroundColor: "#2196F3",
    padding: 15,
    marginTop: 20,
    alignItems: "center",
    borderRadius: 5,
  },
  predictButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
});
