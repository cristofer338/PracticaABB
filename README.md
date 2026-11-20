# PracticaABB
# Tarea 4.2: Árbol Binario de Búsqueda (C#)

**Alumno:** Cristofer Alejandro Barboza Chávez  
**Carrera:** Informática  
**Matrícula:** I24050398  
**Institución:** Tecnológico Nacional de México  
**Materia:** Estructuras de datos
**Entorno:** Aplicación de consola en C# (.NET / Visual Studio)

---

## Descripción del proyecto

Este proyecto implementa un **Árbol Binario de Búsqueda (ABB)** en **C#** como aplicación de consola interactiva. En un ABB, los valores menores a un nodo se almacenan en su subárbol izquierdo y los valores mayores en su subárbol derecho, evitando duplicados para mantener el orden jerárquico.

---

## Funcionalidades implementadas

* **Inserción (`Insertar`):** Agrega un nuevo valor entero en la posición correspondiente según la regla del ABB.
* **Búsqueda (`Buscar`):** Verifica si un valor existe dentro del árbol (`true` / `false`).
* **Eliminación (`Eliminar`):** Resuelve los tres casos habituales:
  1. **Nodo hoja (0 hijos):** se elimina directamente.
  2. **Nodo con un hijo:** se enlaza el padre con el único hijo del nodo eliminado.
  3. **Nodo con dos hijos:** se sustituye por el **sucesor inorden** (valor mínimo del subárbol derecho) y se elimina dicho sucesor.
* **Recorridos:**
  * **Preorden:** Raíz → Izquierdo → Derecho.
  * **Inorden:** Izquierdo → Raíz → Derecho (muestra los elementos ordenados de menor a mayor).
  * **Postorden:** Izquierdo → Derecho → Raíz.
* **Métricas del árbol:**
  * **Altura (`Altura`):** Calculada en número de aristas (`-1` si el árbol está vacío, `0` si solo contiene la raíz).
  * **Conteo de nodos (`ContarNodos`):** Devuelve el total de nodos presentes en el árbol.

---

## Ejecución en Visual Studio

1. Abre **Visual Studio** y selecciona **Crear un proyecto** → **Aplicación de consola** (C#).
2. Asigna un nombre al proyecto (por ejemplo, `PracticaABB`) y créalo.
3. Reemplaza el contenido de `Program.cs` con el código del Árbol Binario de Búsqueda.
4. Ejecuta el programa con **Ctrl + F5** (o *Iniciar sin depurar*) y utiliza el menú interactivo en consola.
