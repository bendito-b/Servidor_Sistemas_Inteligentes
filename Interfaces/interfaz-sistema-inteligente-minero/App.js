import React, { useState } from "react";
import {
  StyleSheet,
  Text,
  View,
  TextInput,
  Pressable,
  ScrollView,
  Modal,
  FlatList,
} from "react-native";

export default function App() {
  const [selectedSoil, setSelectedSoil] = useState(null);
  const [headerValue, setHeaderValue] = useState(1);
  const [inputValues, setInputValues] = useState({});
  const [errorMessages, setErrorMessages] = useState({});
  const [modalVisible, setModalVisible] = useState(false);
  const [predictions, setPredictions] = useState([]);

  const soils = [
    {
      name: "Sedimentarios",
      inputs: [
        { name: "Presión Geológica", unit: "MPa", min: 50.0, max: 300.0 },
        { name: "Densidad del Suelo", unit: "g/cm³", min: 1.5, max: 3.5 },
        { name: "Profundidad de Fisuras", unit: "m", min: 100.0, max: 700.0 },
        { name: "Índice de Fracturamiento", unit: null, min: 0.8, max: 2.8 },
        {
          name: "Profundidad de Perforación",
          unit: "m",
          min: 100.0,
          max: 700.0,
        },
      ],
      api: "/api/Hechos/ActividadGeomecanica",
    },
    {
      name: "Vertisoles",
      inputs: [
        { name: "Presión Geológica", unit: "MPa", min: 100.0, max: 400.0 },
        { name: "Densidad del Suelo", unit: "g/cm³", min: 2.1, max: 3.7 },
        { name: "Profundidad de Fisuras", unit: "m", min: 100.0, max: 700.0 },
        { name: "Índice de Fracturamiento", unit: null, min: 1.2, max: 3.5 },
        {
          name: "Profundidad de Perforación",
          unit: "m",
          min: 150.0,
          max: 800.0,
        },
      ],
      api: "/api/Hechos/ActividadGeomecanica",
    },
    {
      name: "Residuales",
      inputs: [
        { name: "Elementos Traza", unit: "ppm", min: 5.0, max: 250.0 },
        { name: "Óxidos Metálicos", unit: "%", min: 0.0, max: 30.0 },
        { name: "Potencial de Hidrógeno", unit: null, min: 4.5, max: 8.0 },
        { name: "Conductividad Iónica", unit: "mS/cm", min: 0.5, max: 4.0 },
        { name: "Meteorización", unit: "%", min: 30.0, max: 90.0 },
      ],
      api: "/api/Hechos/ComposicionGeoquimica",
    },
    {
      name: "Oxisoles",
      inputs: [
        { name: "Elementos Traza", unit: "ppm", min: 0.0, max: 350.0 },
        { name: "Óxidos Metálicos", unit: "%", min: 0.0, max: 35.0 },
        { name: "Potencial de Hidrógeno", unit: null, min: 4.0, max: 7.5 },
        { name: "Conductividad Iónica", unit: "mS/cm", min: 0.0, max: 5.0 },
        { name: "Meteorización", unit: "%", min: 20.0, max: 100.0 },
      ],
      api: "/api/Hechos/ComposicionGeoquimica",
    },
    {
      name: "Lateritas",
      inputs: [
        {
          name: "Resistividad Eléctrica",
          unit: "10⁻³ Ω·m",
          min: 0.45,
          max: 1.9,
        },
        { name: "Magnetismo", unit: "A/m", min: 1.0, max: 3.0 },
        { name: "Saturación de Agua", unit: "%", min: 12.0, max: 33.0 },
        { name: "Susceptibilidad Magnética", unit: "10⁻³", min: 1.0, max: 3.5 },
        {
          name: "Contenido de Óxidos Metálicos",
          unit: "%",
          min: 3.0,
          max: 40.0,
        },
      ],
      api: "/api/Hechos/ConductividadMagnetismo",
    },
    {
      name: "Glaciales",
      inputs: [
        {
          name: "Resistividad Eléctrica",
          unit: "10⁻³ Ω·m",
          min: 0.8,
          max: 2.3,
        },
        { name: "Magnetismo", unit: "A/m", min: 0.7, max: 2.6 },
        { name: "Saturación de Agua", unit: "%", min: 6.0, max: 30.0 },
        { name: "Susceptibilidad Magnética", unit: "10⁻³", min: 0.5, max: 4.0 },
        {
          name: "Contenido de Óxidos Metálicos",
          unit: "%",
          min: 0.0,
          max: 45.0,
        },
      ],
      api: "/api/Hechos/ConductividadMagnetismo",
    },
    {
      name: "Andosoles",
      inputs: [
        { name: "Potencial de Hidrógeno", unit: null, min: 4.2, max: 7.0 },
        { name: "Temperatura", unit: "°C", min: 190.0, max: 440.0 },
        { name: "Porosidad", unit: "%", min: 10.0, max: 30.0 },
        { name: "Agua Subterránea", unit: "m³", min: 150.0, max: 450.0 },
        { name: "Alteración Hidrotermal", unit: "%", min: 20.0, max: 70.0 },
      ],
      api: "/api/Hechos/PotencialHidrotermal",
    },
    {
      name: "Entisoles",
      inputs: [
        { name: "Potencial de Hidrógeno", unit: null, min: 5.0, max: 7.7 },
        { name: "Temperatura", unit: "°C", min: 230.0, max: 450.0 },
        { name: "Porosidad", unit: "%", min: 7.0, max: 25.0 },
        { name: "Agua Subterránea", unit: "m³", min: 100.0, max: 400.0 },
        { name: "Alteración Hidrotermal", unit: "%", min: 15.0, max: 65.0 },
      ],
      api: "/api/Hechos/PotencialHidrotermal",
    },
  ];

  const reset = () => {
    setSelectedSoil(null);
    setHeaderValue(1);
    setInputValues({});
    setErrorMessages({});
  };

  const handleInputChange = (field, value, min, max) => {
    const sanitizedField = field.replace(/\s+/g, "");
    const numericValue = parseFloat(value);

    if (isNaN(numericValue) || numericValue < min || numericValue > max) {
      setErrorMessages((prev) => ({
        ...prev,
        [sanitizedField]: `El valor debe estar entre ${min} y ${max}.`,
      }));
    } else {
      setErrorMessages((prev) => ({
        ...prev,
        [sanitizedField]: null,
      }));
    }

    setInputValues((prevValues) => ({
      ...prevValues,
      [sanitizedField]: value,
    }));
  };

  const sendData = async () => {
    if (!selectedSoil) return;

    const hasErrors = Object.values(errorMessages).some((msg) => msg);
    if (hasErrors) {
      alert("Corrige los errores antes de continuar.");
      return;
    }

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
      setPredictions(responseData);
      setModalVisible(true);
    } catch (error) {
      alert(`Error: ${error.message}`);
    }
  };

  const renderInputs = (inputs) => (
    <View>
      {inputs.map((input, index) => {
        const sanitizedField = input.name.replace(/\s+/g, "");
        return (
          <View key={index} style={styles.inputGroup}>
            <Text style={styles.label}>{input.name}</Text>
            <View style={styles.inputWithUnit}>
              <TextInput
                style={styles.input}
                keyboardType="numeric"
                placeholder={`Entre ${input.min} y ${input.max}`}
                value={inputValues[sanitizedField] || ""}
                onChangeText={(value) =>
                  handleInputChange(input.name, value, input.min, input.max)
                }
              />
              {input.unit && <Text style={styles.unit}>{input.unit}</Text>}
            </View>
            <View style={styles.errorContainer}>
              {errorMessages[sanitizedField] && (
                <Text style={styles.errorText}>
                  {errorMessages[sanitizedField]}
                </Text>
              )}
            </View>
          </View>
        );
      })}
      <Pressable style={styles.predictButton} onPress={sendData}>
        <Text style={styles.predictButtonText}>Predecir</Text>
      </Pressable>
    </View>
  );

  return (
    <ScrollView contentContainerStyle={styles.container}>
      {!selectedSoil ? (
        <View style={styles.buttonContainer}>
          {soils.map((soil, index) => (
            <Pressable
              key={index}
              style={styles.soilButton}
              onPress={() => {
                setSelectedSoil(soil);
                setHeaderValue(index % 2 === 0 ? 1 : 2);
              }}
            >
              <Text style={styles.soilButtonText}>{soil.name}</Text>
            </Pressable>
          ))}
        </View>
      ) : (
        <View style={styles.inputContainer}>
          <Text style={styles.selectedSoilTitle}>{selectedSoil.name}</Text>
          <Pressable style={styles.backButton} onPress={reset}>
            <Text style={styles.backButtonText}>Regresar</Text>
          </Pressable>
          {renderInputs(selectedSoil.inputs)}
        </View>
      )}

      <Modal
        animationType="slide"
        transparent={true}
        visible={modalVisible}
        onRequestClose={() => setModalVisible(false)}
      >
        <View style={styles.modalOverlay}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Predicciones</Text>
            <FlatList
              data={predictions}
              keyExtractor={(item, index) => index.toString()}
              renderItem={({ item }) => (
                <View style={styles.predictionItem}>
                  <Text style={styles.predictionText}>{item.mineral}</Text>
                  <Text style={styles.predictionText}>
                    Probabilidad: {item.probabilidad}%
                  </Text>
                </View>
              )}
            />
            <Pressable
              style={styles.closeButton}
              onPress={() => setModalVisible(false)}
            >
              <Text style={styles.closeButtonText}>Cerrar</Text>
            </Pressable>
          </View>
        </View>
      </Modal>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: {
    flexGrow: 1,
    padding: 20,
    backgroundColor: "#000",
    alignItems: "center",
    justifyContent: "center", // Centrar contenido vertical y horizontalmente
  },
  buttonContainer: {
    alignItems: "center",
    flexDirection: "row",
    flexWrap: "wrap",
    justifyContent: "center", // Asegurar que estén centrados horizontalmente
  },
  soilButton: {
    backgroundColor: "#4CAF50",
    padding: 10,
    margin: 9,
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
  selectedSoilTitle: {
    color: "#fff",
    fontSize: 20,
    fontWeight: "bold",
    textAlign: "center",
    marginBottom: 20,
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
    color: "#f0f0f0",
    fontSize: 14,
    marginBottom: 5,
  },
  inputWithUnit: {
    flexDirection: "row",
    alignItems: "center",
  },
  input: {
    flex: 1,
    color: "#f0f0f0",
    borderWidth: 2,
    borderColor: "#2196F3",
    borderRadius: 9,
    padding: 8,
    fontSize: 14,
  },
  unit: {
    color: "#f0f0f0",
    marginLeft: 10,
    fontSize: 14,
  },
  errorContainer: {
    minHeight: 18,
  },
  errorText: {
    color: "#f44336",
    fontSize: 12,
    marginTop: 5,
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
  modalOverlay: {
    flex: 1,
    backgroundColor: "rgba(0, 0, 0, 0.8)",
    justifyContent: "center",
    alignItems: "center",
  },
  modalContent: {
    width: "80%",
    backgroundColor: "#fff",
    borderRadius: 10,
    padding: 20,
    alignItems: "center",
  },
  modalTitle: {
    fontSize: 18,
    fontWeight: "bold",
    marginBottom: 15,
  },
  predictionItem: {
    marginBottom: 10,
  },
  predictionText: {
    fontSize: 16,
  },
  closeButton: {
    backgroundColor: "#2196F3",
    padding: 10,
    marginTop: 20,
    borderRadius: 5,
    width: "100%",
    alignItems: "center",
  },
  closeButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
});
