function solve() {
  /////////////////////
  const form = document.querySelector('#form > form');
  const courseList = document.getElementById('list');
  /////////////////////
  const nameInputElement = document.getElementById('course-name');
  let courseName;
  const typeInputElement = document.getElementById('course-type');
  let courseType;
  const descriptionInputElement = document.getElementById('description');
  let courseDescription;
  const teacherInputElement = document.getElementById('teacher-name');
  let courseTeacher;
  /////////////////////
  const addButton = document.getElementById('add-course');
  addButton.addEventListener('click', addNewCourse);

  const editButton = document.getElementById('edit-course');
  editButton.addEventListener('click', editEvent);

  const loadButton = document.getElementById('load-course');
  loadButton.addEventListener('click', loadAllCourses);
  /////////////////////
  const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';

  let courseId;
  /////////////////////

  function loadAllCourses(e) {
    if (e) {
      e.preventDefault();
    }

    courseList.innerHTML = '';

    fetch(BASE_URL)
      .then((data) => data.json())
      .then((response) => {
        for (const { title, type, description, teacher, _id } of Object.values(
          response
        )) {
          /////////////////////
          const courseContainer = createElement(
            'div',
            '',
            `${_id}`,
            courseList,
            ['container']
          );

          const titleH2 = createElement('h2', `${title}`, '', courseContainer);
          const teacherH3 = createElement(
            'h3',
            `${teacher}`,
            '',
            courseContainer
          );
          const typeH3 = createElement('h3', `${type}`, '', courseContainer);
          const descriptionH4 = createElement(
            'h4',
            `${description}`,
            '',
            courseContainer
          );
          /////////////////////
          const courseEditBtn = createElement(
            'button',
            'Edit Course',
            '',
            courseContainer,
            ['edit-btn']
          );
          courseEditBtn.addEventListener('click', loadFormEdit);

          const courseFinishBtn = createElement(
            'button',
            'Finish',
            '',
            courseContainer,
            ['finish-btn']
          );
          courseFinishBtn.addEventListener('click', finishCourse);
          /////////////////////
        }
      });
  }

  function addNewCourse(e) {
    if (e) {
      e.preventDefault();
    }
    courseName = nameInputElement.value;
    courseType = typeInputElement.value;
    courseDescription = descriptionInputElement.value;
    courseTeacher = teacherInputElement.value;

    if (courseName && courseType && courseDescription && courseTeacher) {
      if (
        courseType === 'Long' ||
        courseType === 'Medium' ||
        courseType === 'Short'
      ) {
        const httpHeaders = {
          method: 'POST',
          body: JSON.stringify({
            title: courseName,
            type: courseType,
            description: courseDescription,
            teacher: courseTeacher,
          }),
        };

        form.reset();

        fetch(BASE_URL, httpHeaders).then(() => loadAllCourses());
      }
    }
  }

  function loadFormEdit(e) {
    if (e) {
      e.preventDefault();
    }

    const currentId = e.currentTarget.parentNode.id;
    courseId = currentId;

    nameInputElement.value = e.currentTarget.parentNode.children[0].textContent;

    teacherInputElement.value =
      e.currentTarget.parentNode.children[1].textContent;

    typeInputElement.value = e.currentTarget.parentNode.children[2].textContent;

    descriptionInputElement.value =
      e.currentTarget.parentNode.children[3].textContent;

    // fetch(`${BASE_URL}${currentId}`, { method: 'GET' })
    //   .then((data) => data.json())
    //   .then((response) => {
    //     nameInputElement.value = response['title'];
    //     typeInputElement.value = response['type'];
    //     teacherInputElement.value = response['teacher'];
    //     descriptionInputElement.value = response['description'];
    //   });
    e.currentTarget.parentNode.remove();

    addButton.disabled = true;
    editButton.disabled = false;
  }

  function editEvent(e) {
    if (e) {
      e.preventDefault();
    }

    courseName = nameInputElement.value;
    console.log(courseName);
    courseType = typeInputElement.value;
    console.log(courseType);
    courseDescription = descriptionInputElement.value;
    courseTeacher = teacherInputElement.value;

    if (courseName && courseType && courseDescription && courseTeacher) {
      if (
        courseType === 'Long' ||
        courseType === 'Medium' ||
        courseType === 'Short'
      ) {
        const httpHeaders = {
          method: 'PUT',
          body: JSON.stringify({
            title: courseName,
            type: courseType,
            description: courseDescription,
            teacher: courseTeacher,
            _id: courseId,
          }),
        };

        fetch(`${BASE_URL}${courseId}`, httpHeaders).then(() =>
          loadAllCourses()
        );

        addButton.disabled = false;
        editButton.disabled = true;
        form.reset();
      }
    }
  }

  function finishCourse(e) {
    if (e) {
      e.preventDefault();
    }
    const currentId = e.currentTarget.parentNode.id;

    fetch(`${BASE_URL}${currentId}`, { method: 'DELETE' }).then(() =>
      loadAllCourses()
    );
  }

  function createElement(type, content, id, parentNode, classes, attributes) {
    const newElement = document.createElement(type);

    if (content && type !== 'input') {
      newElement.textContent = content;
    }

    if (content && type === 'input') {
      newElement.value = content;
    }

    if (id) {
      newElement.id = id;
    }

    if (parentNode) {
      parentNode.appendChild(newElement);
    }

    if (classes) {
      newElement.classList.add(...classes);
    }

    if (attributes) {
      for (const key in attributes) {
        newElement.setAttribute(key, attributes[key]);
      }
    }

    return newElement;
  }
}

solve();
