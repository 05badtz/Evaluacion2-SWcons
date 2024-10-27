# Evaluación 2

## Descripción del Proyecto
La aplicación está diseñada para manejar datos de alumnos y asignaturas en una base de datos. Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre ambas entidades, proporcionando una interfaz fácil de usar.

## Tecnologías Utilizadas
- **Lenguaje**: C#
- **Framework**: Windows Forms
- **Base de Datos**: TablaAlumnoAsignaturas.sql
- **Capas**:
  - **Capa de Presentación (UI)**: Interfaz de usuario en Windows Forms.
  - **Capa de Acceso a Datos (DAL)**: Manejo de la conexión y consultas a la base de datos.
  - **Capa de Objetos de Negocio (BOL)**: Clases que representan los objetos de negocio (alumnos y asignaturas).
  - **Capa de Lógica de Negocios (BL)**: Implementación de la lógica de negocio y las reglas de la aplicación.

## Instalación
1. Clone este repositorio en su máquina local.
   ```bash
   git clone https://github.com/05badtz/Evaluacion2-SWcons.git
2. Abra el proyecto en Visual Studio.
3. Asegúrese de tener la base de datos configurada y accesible.
4. Para configurar la base de datos abra sql server y ejecute la query "DataBase.sql".
5. Ejecute la aplicación.

## Uso
1. Abra la aplicación.
2. En las capas DAL de Alumnos y Asignaturas ingrese la cadena de conexión de la base de datos local.
3. Navegue a la sección deseada para gestionar alumnos o asignaturas.
4. Utilice las opciones para agregar, editar o eliminar registros.
5. Para modificar:
    - Debe seleccionar una fila de la lista, dar click derecho y seleccionar la opción "Modificar".
    - "Alumnos" no puede repetir el email o el número de matricula.
    - "Asignaturas" no puede repetir el nombre de la asignatura.
6. Para eliminar:
    - Debe seleccionar una fila de la lista, dar click derecho y seleccionar la opción "Eliminar".
7. Los cambios serán guardados automáticamente y se verán reflejados en el listado.


