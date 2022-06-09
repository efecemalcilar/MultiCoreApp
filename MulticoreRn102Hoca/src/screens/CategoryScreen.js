import React, {Component} from 'react';
import {
  View,
  Text,
  Button,
  StyleSheet,
  ActivityIndicator,
  ScrollView,
} from 'react-native';
import {DataTable} from 'react-native-paper';

export default class CategoryScreen extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: true,
      dataSource: [],
    };
  }
  componentDidMount() {
    return fetch('https://multicoreapp-api-yb3.conveyor.cloud/api/category')
      .then(response => response.json())
      .then(responseJson => {
        this.setState({isLoading: false, dataSource: responseJson});
      })
      .catch(error => console.log('HATA : ' + error));
  }
  render() {
    if (this.state.isLoading) {
      return (
        <View style={{flex: 1, padding: 20}}>
          <ActivityIndicator />
        </View>
      );
    } else {
      return (
        <ScrollView style={styles.container}>
          <DataTable>
            <DataTable.Header>
              <DataTable.Title>Id</DataTable.Title>
              <DataTable.Title>Category</DataTable.Title>
            </DataTable.Header>

            {this.state.dataSource.map((item, key) => (
              <DataTable.Row key={key}>
                <DataTable.Cell>{item.id}</DataTable.Cell>
                <DataTable.Cell>{item.name}</DataTable.Cell>
              </DataTable.Row>
            ))}
          </DataTable>
        </ScrollView>
      );
    }
  }
}

const styles = StyleSheet.create({
  container: {
    paddingTop: 100,
    paddingHorizontal: 30,
  },
});

// export default function CategoryScreen(navigation) {
//   const {navigate} = navigation;
//   return (
//     <View style={{flex: 1, alignItems: 'center', justifiyContent: 'center'}}>
//       <View>
//         <Text>CategoryScreen</Text>
//       </View>
//     </View>
//   );
// }
